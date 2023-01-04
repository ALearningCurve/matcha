using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Gun : ScriptableObject
{
    public float bulletSpeed;

    public Vector2[] bulletPositions;

    public bool isExpandingBullet;


    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        float bulletCount = 10f;


        shootingPoint.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        shootingPoint.transform.Rotate(0.0f, 0.0f, bulletCount / 2, Space.Self);

        for (int i = 0; i < bulletCount; i++)
        {
            float bulletSize = Random.Range(0.2f, 0.3f);

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

}
