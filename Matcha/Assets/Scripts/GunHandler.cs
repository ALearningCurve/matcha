using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunHandler : MonoBehaviour
{
    public IWeapon weapon; //This needs to be public so that the SwapWeapon script can access it because the weapon swap should occur when the player touches a gun, not when the gun 
    //it was private before, so is it bad that this is public? 

    private Color nextColor;

    [SerializeField] private Camera cam;

    [Header ("Gun Stuff")]
    [SerializeField] private SpriteRenderer gunSprite;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer bulletSprite;


    [Header("Player Stuff")]
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;


    
    // STAYS IN CONTROLLER
    [SerializeField] protected GameObject shootingPoint;

    public PlayerInputActions playerControls;
    private InputAction look;
    private InputAction fire;

    private Vector2 mousePos;

// STAYS IN CONTROLLER
    //private float xBoundary = 15f;
    //private float yBoundary = 9.5f;


     private Vector2 lookDir;
     private float angle;

    [Header ("Gun Aiming Visuals")]
    [SerializeField] private GameObject crosshair;
    [SerializeField] private SpriteRenderer crosshairSpriteRenderer;
    [SerializeField] private SpriteRenderer arrowSpriteRenderer;


    [Header ("Scriptable Object")]
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
        crosshairSpriteRenderer.color = color;
        arrowSpriteRenderer.color = color;

    }



    private void OnEnable()
    {
        
        look = playerControls.Player.Look;
        look.Enable();
      

        //playerControls.Player is the Player action map from the PlayerInputActions in the inspector (see Input folder in the Project panel)
        //playerControls.Player.Fire is the action named Fire from the PlayerInputActions actionmap player
        //we create a privateInputAction and set it equal to the input detected from our fire action, in this case being the left click button
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire; //when the InputAction fire is performed, we call the private void method Fire from this script



    }

    private void OnDisable()
    {
        look.Disable();
        fire.Disable();
    }

    
    private void Fire(InputAction.CallbackContext context)
    {
        int randomColor = Random.Range(0, theColors.colors.Count);

        this.weapon.shoot(this.shootingPoint, this.bulletPrefab, this.nextColor);

        Color color = theColors.colors[randomColor];
        this.nextColor = color;
        crosshairSpriteRenderer.color = color;
        arrowSpriteRenderer.color = color;
        gunSprite.color = color;

    }

    private void flipXFalse()
    {
        playerSpriteRenderer.flipX = false;
        gunSprite.flipX = false;
    }

    private void flipXTrue()
    {
        playerSpriteRenderer.flipX = true;
        gunSprite.flipX = true;
    }


    private void Update()
    {

        mousePos = cam.ScreenToWorldPoint(playerControls.Player.Look.ReadValue<Vector2>());

        crosshair.transform.position = mousePos;

        if (mousePos.x > player.transform.position.x)
        {
            flipXFalse();
        }
        if (mousePos.x < player.transform.position.x)
        {
            flipXTrue();
        }

    }

    private void FixedUpdate()
    {
        rb.position = playerRB.position;

        lookDir = mousePos - rb.position;


        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

}
