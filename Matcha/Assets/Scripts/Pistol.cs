using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : AWeapon
{
    public Pistol()
    {
    }

    private void Awake() {
        this.colors =
            new List<Color>(new [] { color1, color2, color3, color4, color5 });

        this.gunSprite = GetComponent<SpriteRenderer>();
        this.gunSprite.color = Color.white;

        this.bulletSprite = bulletPrefabulous.GetComponent<SpriteRenderer>();
        this.bulletSprite.color = Color.white;

        // add something to do bulletprefab in code
        this.bulletSpeed = 20f;

    }

    public override void shoot(GameObject shootingPoint)
    {
        GameObject bullet =
            Instantiate(this.bulletPrefabulous,
            shootingPoint.transform.position,
            shootingPoint.transform.rotation);


        //     GameObject bullet = Instantiate(new GameObject("go3", typeof(Rigidbody2D)), new Vector3(0f, 0f, 0f), Quaternion.identity);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        bulletRB
            .AddForce(shootingPoint.transform.up * bulletSpeed,
            ForceMode2D.Impulse);

            //     bulletRB
            // .AddForce(new Vector2(20f, 20f),
            // ForceMode2D.Impulse);

        //Set the SpriteRenderer to the Color defined by the Sliders
        // int randomColor = Random.Range(0, this.colors.Count);
        // gunSprite.color = colors[randomColor];
        // bulletSprite.color = colors[randomColor];
    }
}
