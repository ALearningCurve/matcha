using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Shotgun":
                gun.GetComponent<GunHandler>().weapon = new Shotgun();
                break;

            case "Sniper":
                gun.GetComponent<GunHandler>().weapon = new Sniper();
                break;

            case "Pistol":
                gun.GetComponent<GunHandler>().weapon = new Pistol();
                break;


            case "BigBoy":
                gun.GetComponent<GunHandler>().weapon = new BigBoy();
                break;


            case "BurstShot":
                gun.GetComponent<GunHandler>().weapon = new BurstShot();
                break;

        }

    }

}
