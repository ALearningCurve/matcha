using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{

    // I don't think "public Shotgun(){}" is doing anything but it is giving a yellow warning sign in the console,
    // this kinda explains it https://answers.unity.com/questions/653904/you-are-trying-to-create-a-monobehaviour-using-the-2.html\
    public Shotgun() { }

    protected float bulletSpeed = 30f;



    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        float bulletCount = 10f;


        shootingPoint.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        shootingPoint.transform.Rotate(0.0f, 0.0f, bulletCount / 2, Space.Self);

        for (int i = 0; i < bulletCount; i++)
        {
            float bulletSize = Random.Range(0.2f, 0.5f);

            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);

            bullet.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
            bullet.GetComponent<TrailRenderer>().widthMultiplier = bulletSize;

            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.AddForce(shootingPoint.transform.right * bulletSpeed, ForceMode2D.Impulse);

            bullet.GetComponent<SpriteRenderer>().color = color;

            shootingPoint.transform.Rotate(0.0f, 0.0f, -1f, Space.Self);

        }

        shootingPoint.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }


    public void reload()
    {
        throw new System.NotImplementedException();
    }
}



