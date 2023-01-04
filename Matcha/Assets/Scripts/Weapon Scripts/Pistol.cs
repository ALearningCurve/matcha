using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{

    private float bulletDelay = 10f;
    private float timeDelay = 2f;

    private bool canShoot = true;

    private IEnumerator coroutine;

    protected float bulletSpeed = 50f;

    // I don't think "public Pistol(){}" is doing anything but it is giving a yellow warning sign in the console,
    // this kinda explains it https://answers.unity.com/questions/653904/you-are-trying-to-create-a-monobehaviour-using-the-2.html\
    public Pistol() 
    {
    }

    //trying to implement the delay but im having trouble because it is giving a null reference exception when I try to use a coroutine.
    //I think this coulb be because the coroutine needs to be passed through the interface although I'm not certain
    //we kinda need coroutines to work in order to have a delay between shots (coroutines are basically timers)

    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);

            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.AddForce(shootingPoint.transform.right * bulletSpeed, ForceMode2D.Impulse);

            bullet.GetComponent<SpriteRenderer>().color = color;


        }

    }


public void reload()
    {
        throw new System.NotImplementedException();
    }
}
