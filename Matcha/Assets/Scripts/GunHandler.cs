using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunHandler : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Camera cam;

    [SerializeField] GameObject player;
    
    Vector2 mousePos;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shootingPoint;

    [SerializeField] private float bulletSpeed = 20f;

    public PlayerInputActions playerControls;
    private InputAction look;
    private InputAction fire;

    private Vector2 mousePosition;

    private void Awake()
    {
        //we create a variable called playerControls which is equal to a new instance of the PlayerInputActions asset that we created in the inspector
        playerControls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
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

    }

    private void Fire(InputAction.CallbackContext context)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

    }



    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(mousePosition);
    }

    private void FixedUpdate()
    {
        rb.position = player.GetComponent<Rigidbody2D>().position;


        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }


}
