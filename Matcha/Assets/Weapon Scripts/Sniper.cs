using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour, IWeapon
{
    
    protected float bulletSpeed = 50f;

    
    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);

        bullet.transform.localScale = new Vector3(.5f, .5f, .5f); //makes bullet smaller
        bullet.GetComponent<TrailRenderer>().widthMultiplier = 0.5f; // maker trail renderer for bullet smaller to match the bullet size


        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        bullet.GetComponent<SpriteRenderer>().color = color; 

    }

    public void reload()
    {
        throw new System.NotImplementedException();
    }
}
