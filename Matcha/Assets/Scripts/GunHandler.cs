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

    private Vector2 mousePos;
    private Vector2 mousePosition;


    //make a list or array (not sure which is better) that has like 10 or so colors in it. WHen you shoot gun, change color of spriterenderer of gun and bullet to a random color from the list/array;
    //
    List<Color> colors = new List<Color>();

    private void Awake()
    {
        //we create a variable called playerControls which is equal to a new instance of the PlayerInputActions asset that we created in the inspector
        playerControls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        gunSprite = GetComponent<SpriteRenderer>();
        bulletSprite = bulletPrefab.GetComponent<SpriteRenderer>();

        gunSprite.color = Color.white;
        bulletSprite.color = Color.white;

        //there is probably a better way of doing this 
        //pls optimize thx
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.magenta);
        colors.Add(Color.yellow);
        colors.Add(Color.cyan);
        colors.Add(Color.white);

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


    }

    private void OnDisable()
    {
        look.Disable();
        fire.Disable();
    }



    private void Look(InputAction.CallbackContext context)
    {
        mousePosition = playerControls.Player.Look.ReadValue<Vector2>();
        //Debug.Log(mousePosition);

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



    }



    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(mousePosition);

        // Debug.Log(mousePos);


        if(mousePos.x > player.transform.position.x)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(mousePos.x < player.transform.position.x)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void FixedUpdate()
    {
        rb.position = player.GetComponent<Rigidbody2D>().position;


        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }





}
