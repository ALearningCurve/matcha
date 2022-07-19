using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject bulletPrefab;
    
    private bool isGrounded = false;

    private Vector2 lastVelocity = Vector2.zero;
    private Vector2 moveDirection = Vector2.zero;

    //controls how fast player moves
    [SerializeField] private float speed;

    //controls how high player jumps
    [SerializeField] private float jumpHeight;

    //controls how much force is added downwards when the player is falling
    [SerializeField] private float downGravity;


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

        //if the ground check circle overlaps with the ground, the player is grounded (and can jump again)
        if (Physics2D.OverlapCircle(groundCheck.transform.position, groundCheck.transform.localScale.y/2, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if (isGrounded)
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
    }



    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && coyoteTimeCounter > 0f)
        {
            Debug.Log(coyoteTimeCounter);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }


    }

}