using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{

    protected float bulletSpeed = 15f;

    // I don't think "public Pistol(){}" is doing anything but it is giving a yellow warning sign in the console,
    // this kinda explains it https://answers.unity.com/questions/653904/you-are-trying-to-create-a-monobehaviour-using-the-2.html\
    public Pistol() 
    {
    }

    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        bullet.GetComponent<SpriteRenderer>().color = color; 
            
        
    }
    
        
    

    public void reload()
    {
        throw new System.NotImplementedException();
    }
}
