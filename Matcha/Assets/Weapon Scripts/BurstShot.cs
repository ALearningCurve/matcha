using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShot : MonoBehaviour, IWeapon
{

    protected float bulletSpeed = 10f;

    protected List<Color> colors = new List<Color>(new[] {
        new Color(1f, 1f, 1f, 1f),
        new Color(216f / 255f, 94f / 255f, 0f, 1f),
        new Color(204f / 255f, 121f / 255f, 167f / 255f, 1f),
        new Color(0f, 114f / 255f, 178f / 255f, 1f),
        new Color(240f / 255f, 228f / 255f, 66f / 255f, 1f) });


    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);

            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

            bullet.GetComponent<SpriteRenderer>().color = color;

        }
    }

    public void reload()
    {
        throw new System.NotImplementedException();
    }
}
