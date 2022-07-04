using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public Camera mainCam;

    [SerializeField] private GameObject bulletPrefab;
    
    private bool isFacingRight = true;
    private bool isGrounded = false;

    private Vector2 lastVelocity = Vector2.zero;
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 mousePosition = Vector2.zero;

    //controls how fast player moves
    [SerializeField] private float speed;

    //controls how high player jumps
    [SerializeField] private float jumpHeight;

    //controls how much force is added downwards when the player is falling
    [SerializeField] private float downGravity;


    public PlayerInputActions playerControls;
    private InputAction move;
    private InputAction fire;
    private InputAction look;
    private InputAction jump;


    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;


        look = playerControls.Player.Look;
        look.Enable();
        look.performed += Look;

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
        
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        look.Disable();
        jump.Disable();
    }

    //Update is called once every frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        //if the ground check circle overlaps with the ground, the player is grounded (and can jump again)
        if (Physics2D.OverlapCircle(groundCheck.transform.position, groundCheck.transform.localScale.y, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //flips player 
        if (!isFacingRight && moveDirection.x > 0f)
        {
            Flip();
        }
        else if (isFacingRight && moveDirection.x < 0f)
        {
            Flip();
        }
    }



    //fixed update is also called once every frame but is frame rate independent (good for physics (rigidbody stuff))
    private void FixedUpdate()
    {

        //fixes horizontal drift
        if (moveDirection.x > -0.3f && moveDirection.x < 0.3f)
        {
            moveDirection.x = 0f;
        }

        //this is the line of code that actually moves the player
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);


        //if your current y velocity is less than your y velocity on the last frame (falling), add gravity
        //this makes the jump feel a lot better (less floaty)
        if (rb.velocity.y < lastVelocity.y)
        {
            Vector2 downVelocity = new Vector2(rb.velocity.x, rb.velocity.y - downGravity);
            rb.velocity = downVelocity;
        }

        //stores player velocity on current frame so that it can be checked on the next frame
        lastVelocity = rb.velocity;
    }

    //flips sprite so that it is facing the right way
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, mousePosition, Quaternion.identity);

            //bullet speed and angle calculations still need to be done
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        }
    }

    private void Look(InputAction.CallbackContext context)
    {
        mousePosition = playerControls.Player.Look.ReadValue<Vector2>();
        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


    /*
    //handles horizontal player movement 
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    //handles player jumps
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    //handles firing gun
    public void Fire(InputAction.CallbackContext context)
    {
        //still needs to be done
        Debug.Log("fired");
    }

    public void Look(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

    }

    */

}