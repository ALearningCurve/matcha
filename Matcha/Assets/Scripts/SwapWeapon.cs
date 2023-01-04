using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapWeapon : MonoBehaviour
{
    [SerializeField] private GunHandler gunHandler;
    [SerializeField] private SpriteRenderer gunSprite;

    [SerializeField] private Gun[] Guns;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Shotgun":
                gunHandler.weapon = new Shotgun();
                break;

            case "Sniper":
                gunHandler.weapon = new Sniper();
                break;

            case "Pistol":
                gunHandler.weapon = new Pistol();
                break;


            case "ExpandingBullet":
                gunHandler.weapon = new ExpandingBullet();
                break;


            case "BurstShot":
                gunHandler.weapon = new BurstShot();
                break;
            
        }
        gunSprite.sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;

    }

}


/*

    public PlayerInputActions playerControls;
    private InputAction switchWeapon;


    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        switchWeapon = playerControls.Player.SwitchWeapon;
        switchWeapon.Enable();
        switchWeapon.performed += switchPlayerWeapon;
    }

    private void OnDisable()
    {
        switchWeapon.Disable();
    }


    private void switchPlayerWeapon(InputAction.CallbackContext context)
    {


    }
*/
