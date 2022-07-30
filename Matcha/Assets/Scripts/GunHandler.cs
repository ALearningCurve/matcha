using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunHandler : MonoBehaviour
{

    private SpriteRenderer gunSprite;
    private SpriteRenderer bulletSprite;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shootingPoint;

    [SerializeField] private float bulletSpeed = 20f;

    public PlayerInputActions playerControls;
    private InputAction look;
    private InputAction fire;
    private InputAction controllerLook;

    private Vector2 mousePos;

    private float xBoundary = 15f;
    private float yBoundary = 9.5f;

    private Vector2 pseudoMouseDir;
    private Vector2 lookDir;
    private float angle;

    [SerializeField] private GameObject pseudoMouse;
    [SerializeField] private float pseudoMouseSensitivity;

    private bool usingMouse;


    private Color color1 = new Color(1f, 1f, 1f, 1f);
    private Color color2 = new Color(216f/255f, 94f/255f, 0f, 1f);
    private Color color3 = new Color(204f/255f, 121f/255f, 167f/255f, 1f);
    private Color color4 = new Color(0f, 114f/255f, 178f/255f, 1f);
    private Color color5 = new Color(240f/255f, 228f/255f, 66f/255f, 1f);

    private List<Color> colors;

    //the default colors in unity are only RGBW and CYMK
    //we can make our own custom colors using Color newColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);
    //uses (r, g, b, a) or (r, g, b)



    private void Awake()
    {
        //we create a variable called playerControls which is equal to a new instance of the PlayerInputActions asset that we created in the inspector
        playerControls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        gunSprite = GetComponent<SpriteRenderer>();
        bulletSprite = bulletPrefab.GetComponent<SpriteRenderer>();

        gunSprite.color = Color.white;
        bulletSprite.color = Color.white;

        colors = new List<Color>(new[] { color1, color2, color3, color4, color5 });


    }


    private void OnEnable()
    {
        
        look = playerControls.Player.Look;
        look.Enable();
        look.performed += Look;

        //playerControls.Player is the Player action map from the PlayerInputActions in the inspector (see Input folder in the Project panel)
        //playerControls.Player.Fire is the action named Fire from the PlayerInputActions actionmap player
        //we create a privateInputAction and set it equal to the input detected from our fire action, in this case being the left click button
        fire = playerControls.Player.Fire;
        
        //we enable this InputAction so that when it... is enabled
        fire.Enable();
        
        //when the InputAction fire is performed, we "add" the private void method Fire from this script
        fire.performed += Fire;

        //these comments are mostly for me because I didn't understand the input system until like just now lmao :)

        controllerLook = playerControls.Player.ControllerLook;
        controllerLook.Enable();
        controllerLook.performed += ControllerLook;

    }

    private void OnDisable()
    {
        look.Disable();
        fire.Disable();
        controllerLook.Disable();
    }

    
    private void Look(InputAction.CallbackContext context)
    {
        usingMouse = true;
    }

    
    private void ControllerLook(InputAction.CallbackContext context)
    {
        usingMouse = false;
    }
    

    private void Fire(InputAction.CallbackContext context)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        //Set the SpriteRenderer to the Color defined by the Sliders
        int randomColor = Random.Range(0, colors.Count);
        gunSprite.color = colors[randomColor];
        bulletSprite.color = colors[randomColor];
        pseudoMouse.GetComponent<SpriteRenderer>().color = colors[randomColor];
    }

    private void flipXFalse()
    {
        player.GetComponent<SpriteRenderer>().flipX = false;
        GetComponent<SpriteRenderer>().flipX = false;
    }

    private void flipXTrue()
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        GetComponent<SpriteRenderer>().flipX = true;
    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log(usingMouse);
        if (usingMouse)
        {
            mousePos = cam.ScreenToWorldPoint(playerControls.Player.Look.ReadValue<Vector2>());

            pseudoMouse.transform.position = mousePos;
            
            if(mousePos.x > player.transform.position.x)
            {
                flipXFalse();
            }
            if(mousePos.x < player.transform.position.x)
            {
                flipXTrue();
            }

        }
        else
        {
            pseudoMouse.GetComponent<SpriteRenderer>().enabled = true;

            if (pseudoMouse.transform.position.x > player.transform.position.x)
            {
                flipXFalse();
            }

            if (pseudoMouse.transform.position.x < player.transform.position.x)
            {
                flipXTrue();
            }
        }

    }
     
    private void FixedUpdate()
    {
        rb.position = player.GetComponent<Rigidbody2D>().position;

        if (usingMouse)
        {
            lookDir = mousePos - rb.position;
        }
        else //using controller
        {
            pseudoMouseDir = controllerLook.ReadValue<Vector2>();

            float pMouseX = pseudoMouse.transform.position.x;
            float pMouseY = pseudoMouse.transform.position.y;

            Rigidbody2D pMouseRB = pseudoMouse.GetComponent<Rigidbody2D>();

            //checks if the pseudoMouse is within the bounds of the camera. Uses fixed values so if the camera moves, these numbers have to change.
            //possible dynamic implementation https://forum.unity.com/threads/how-to-detect-screen-edge-in-unity.109583/

            if (pseudoMouse.transform.position.x >= -16f && pseudoMouse.transform.position.x <= 16f && pseudoMouse.transform.position.y >= -10f && pseudoMouse.transform.position.y <= 10f)
            {
                pseudoMouse.GetComponent<Rigidbody2D>().velocity = new Vector2(pseudoMouseDir.x * pseudoMouseSensitivity, pseudoMouseDir.y * pseudoMouseSensitivity);
            }

            switch (pMouseX)
            {
                case < -16f:
                    pMouseRB.velocity = Vector2.zero;
                    pseudoMouse.transform.position = new Vector2(-xBoundary + 0.1f, pseudoMouse.transform.position.y);
                    break;
                case > 16f:
                    pMouseRB.velocity = Vector2.zero;
                    pseudoMouse.transform.position = new Vector2(xBoundary - 0.1f, pseudoMouse.transform.position.y);
                    break;
            }
            switch (pMouseY)
            {
                case < -10f:
                    pMouseRB.velocity = Vector2.zero;
                    pseudoMouse.transform.position = new Vector2(pseudoMouse.transform.position.x, -yBoundary + 0.1f);
                    break;
                case > 10f:
                    pMouseRB.velocity = Vector2.zero;
                    pseudoMouse.transform.position = new Vector2(pseudoMouse.transform.position.x, yBoundary - 1f);
                    break;
            }

            lookDir = new Vector2(pseudoMouse.transform.position.x, pseudoMouse.transform.position.y) - rb.position;
            
        }

        
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

}
