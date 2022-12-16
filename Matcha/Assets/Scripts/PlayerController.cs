using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private ParticleSystem dust;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;


    [Header("Ground Objects")]
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float jumpIsPressed = 0f;

    private Vector2 lastVelocity = Vector2.zero;
    private Vector2 moveDirection = Vector2.zero;

    [Header("Player Movement Settings")]
    //controls how fast player moves
    [SerializeField] private float speed;

    //controls how high player jumps
    [SerializeField] private float jumpHeight;

    //controls how much force is added downwards when the player is falling
    [SerializeField] private float downGravity;

    [SerializeField] private float fastFallSpeed;

    [Header("Buffer Settings")]
    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;


    public PlayerInputActions playerControls;
    private InputAction move;
    private InputAction jump;


    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();


        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
        
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    
    //Update is called once every frame
    void Update()
    {

        moveDirection = move.ReadValue<Vector2>();
        jumpIsPressed = jump.ReadValue<float>();

        //check for when jump button is released. Cannot jmp again until jump button has been pressed again.

        //Debug.Log(jumpIsPressed);

        //if the ground check circle overlaps with the ground, the player is grounded (and can jump again)
        if (Physics2D.OverlapCircle(groundCheck.transform.position, groundCheck.transform.localScale.y/2, groundLayer))
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
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
        //also prevents some forces from affecting the player when not moving because movedirection = 0 when not moving;
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


        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f )
        {
            Debug.Log("Jumped");
            //Debug.Log(jumpIsPressed);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpBufferCounter = 0f;
            CreateDust();
        }

        //when jump is pressed, jump.ReadValue<float>() == 1f;
        if (jumpIsPressed != 1f && rb.velocity.y > 0f)
        {
            coyoteTimeCounter = 0f;

            //gives player varied jump height based on how long the jump button is held down
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //when the player presses down (S Key or down on left stick), they fall faster to the ground.
        if(moveDirection.y < -0.96f)
        {
            
            Vector2 downVelocity = new Vector2(rb.velocity.x, rb.velocity.y - fastFallSpeed);
            rb.velocity = downVelocity;
        }

    }

    private void Jump(InputAction.CallbackContext context)
    {

        if(context.performed){
            jumpBufferCounter = jumpBufferTime;
        }else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        if (context.performed && coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            //Debug.Log(coyoteTimeCounter);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

            jumpBufferCounter = 0f;
            CreateDust();

        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            CreateDust();
        }
    }

    void CreateDust()
    {
        dust.Play();
    }



}