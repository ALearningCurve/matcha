using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunHandler : MonoBehaviour
{
    public IWeapon weapon; //This needs to be public so that the SwapWeapon script can access it because the weapon swap should occur when the player touches a gun, not when the gun 
    //it was private before, so is it bad that this is public? 

    private Color nextColor;

    [SerializeField] private SpriteRenderer gunSprite;
    private SpriteRenderer bulletSprite;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPrefab;

    

    // STAYS IN CONTROLLER
    [SerializeField] protected GameObject shootingPoint;

    public PlayerInputActions playerControls;
    private InputAction look;
    private InputAction fire;
    private InputAction controllerLook;

    private Vector2 mousePos;

// STAYS IN CONTROLLER
    //private float xBoundary = 15f;
    //private float yBoundary = 9.5f;


    //private Vector2 crosshairDir;
     private Vector2 lookDir;
     private float angle;

    [SerializeField] private GameObject crosshair;
    //[SerializeField] private float crosshairSensitivity;
    [SerializeField] private SpriteRenderer crosshairSpriteRenderer;
    [SerializeField] private SpriteRenderer arrowSpriteRenderer;

    private bool usingMouse;

    //the default colors in unity are only RGBW and CYMK
    //we can make our own custom colors using Color newColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);
    //uses (r, g, b, a) or (r, g, b)


    [SerializeField] private ColorList theColors;


    private void Awake()
    {
        //we create a variable called playerControls which is equal to a new instance of the PlayerInputActions asset that we created in the inspector
        playerControls = new PlayerInputActions();
        
        bulletSprite = bulletPrefab.GetComponent<SpriteRenderer>();

        bulletSprite.color = Color.white;
        gunSprite.color = Color.white;
        bulletSprite.color = Color.white;

        this.weapon = new Pistol();


        int randomColor = Random.Range(0, theColors.colors.Count);


        Color color = theColors.colors[randomColor];
        this.nextColor = color;
        crosshair.GetComponent<SpriteRenderer>().color = color;
        arrowSpriteRenderer.color = color;

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
        // GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
        // Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        // bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        // //Set the SpriteRenderer to the Color defined by the Sliders
        int randomColor = Random.Range(0, theColors.colors.Count);
        // gunSprite.color = colors[randomColor];
        // bulletSprite.color = colors[randomColor];
        


        this.weapon.shoot(this.shootingPoint, this.bulletPrefab, this.nextColor);

        Color color = theColors.colors[randomColor];
        this.nextColor = color;
        crosshairSpriteRenderer.color = color;
        arrowSpriteRenderer.color = color;
        gunSprite.color = color;

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

            crosshair.transform.position = mousePos;
            
            if(mousePos.x > player.transform.position.x)
            {
                flipXFalse();
            }
            if(mousePos.x < player.transform.position.x)
            {
                flipXTrue();
            }

        }/*
        else
        {
            crosshairSpriteRenderer.enabled = true;

            if (crosshair.transform.position.x > player.transform.position.x)
            {
                flipXFalse();
            }

            if (crosshair.transform.position.x < player.transform.position.x)
            {
                flipXTrue();
            }
        }*/

    }
     
    private void FixedUpdate()
    {
        rb.position = player.GetComponent<Rigidbody2D>().position;


        if (usingMouse)
        {
            lookDir = mousePos - rb.position;

            //Debug.Log(controllerLook.ReadValue<Vector2>());
        }

        // else //using controller
        // {
        //     crosshairDir = controllerLook.ReadValue<Vector2>();

        //     float pMouseX = crosshair.transform.position.x;
        //     float pMouseY = crosshair.transform.position.y;

        //     Rigidbody2D pMouseRB = crosshair.GetComponent<Rigidbody2D>();

        //     //checks if the crosshair is within the bounds of the camera. Uses fixed values so if the camera moves, these numbers have to change.
        //     //possible dynamic implementation https://forum.unity.com/threads/how-to-detect-screen-edge-in-unity.109583/

        //     if (crosshair.transform.position.x >= -16f && crosshair.transform.position.x <= 16f && crosshair.transform.position.y >= -10f && crosshair.transform.position.y <= 10f)
        //     {
        //         crosshair.GetComponent<Rigidbody2D>().velocity = new Vector2(crosshairDir.x * crosshairSensitivity, crosshairDir.y * crosshairSensitivity);
        //     }

        //     switch (pMouseX)
        //     {
        //         case < -16f:
        //             pMouseRB.velocity = Vector2.zero;
        //             crosshair.transform.position = new Vector2(-xBoundary + 0.1f, crosshair.transform.position.y);
        //             break;
        //         case > 16f:
        //             pMouseRB.velocity = Vector2.zero;
        //             crosshair.transform.position = new Vector2(xBoundary - 0.1f, crosshair.transform.position.y);
        //             break;
        //     }
        //     switch (pMouseY)
        //     {
        //         case < -10f:
        //             pMouseRB.velocity = Vector2.zero;
        //             crosshair.transform.position = new Vector2(crosshair.transform.position.x, -yBoundary + 0.1f);
        //             break;
        //         case > 10f:
        //             pMouseRB.velocity = Vector2.zero;
        //             crosshair.transform.position = new Vector2(crosshair.transform.position.x, yBoundary - 1f);
        //             break;
        //     }

        //     lookDir = new Vector2(crosshair.transform.position.x, crosshair.transform.position.y) - rb.position;
            
        // }

        
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

}
