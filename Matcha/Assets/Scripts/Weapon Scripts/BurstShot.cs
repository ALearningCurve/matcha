using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShot : MonoBehaviour, IWeapon
{

    protected float bulletSpeed = 20f;


    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        GameObject bullet1 = Instantiate(bulletPrefab, shootingPoint.transform.position
                                                       + new Vector3(0f, 0f, 0f), shootingPoint.transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, shootingPoint.transform.position
                                                       + new Vector3(0f, 0f, 0f), shootingPoint.transform.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, shootingPoint.transform.position
                                                       + new Vector3(0f, 0f, 0f), shootingPoint.transform.rotation);

        bullet1.transform.localScale = new Vector3(.7f, .7f, .7f);
        bullet1.GetComponent<TrailRenderer>().widthMultiplier = 0.7f;

        bullet2.transform.localScale = new Vector3(.7f, .7f, .7f);
        bullet2.GetComponent<TrailRenderer>().widthMultiplier = 0.7f;

        bullet3.transform.localScale = new Vector3(.7f, .7f, .7f);
        bullet3.GetComponent<TrailRenderer>().widthMultiplier = 0.7f;

        Rigidbody2D bulletRB1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D bulletRB2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D bulletRB3 = bullet3.GetComponent<Rigidbody2D>();

        bulletRB1.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        shootingPoint.transform.Rotate(0.0f, 0.0f, 10.0f, Space.Self);
        bulletRB2.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        shootingPoint.transform.Rotate(0.0f, 0.0f, -20.0f, Space.Self);

        bulletRB3.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        shootingPoint.transform.Rotate(0.0f, 0.0f, 10.0f, Space.Self);


        bullet1.GetComponent<SpriteRenderer>().color = color;
        bullet2.GetComponent<SpriteRenderer>().color = color;
        bullet3.GetComponent<SpriteRenderer>().color = color;
    }

    public void reload()
    {
        throw new System.NotImplementedException();
    }
}
