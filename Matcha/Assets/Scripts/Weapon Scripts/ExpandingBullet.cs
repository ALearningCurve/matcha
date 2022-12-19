using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//pls change the name to "Expanding Bullet" ty :)
public class ExpandingBullet : MonoBehaviour, IWeapon
{

    protected float bulletSpeed = 2f;


    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);

        bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //makes bullet smaller
        bullet.GetComponent<TrailRenderer>().widthMultiplier = 0.5f; // maker trail renderer for bullet smaller to match the bullet size

        bullet.GetComponent<ExpandBullet>().isExpandingBullet = true;

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        bullet.GetComponent<SpriteRenderer>().color = color;
    }

    public void reload()
    {
        throw new System.NotImplementedException();
    }
}
