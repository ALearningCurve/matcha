using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : AWeapon
{
    public Pistol()
    {
    }

    private void Awake() {
        this.colors = new List<Color>(new [] { color1, color2, color3, color4, color5 });



        this.gunSprite = GetComponent<SpriteRenderer>();
        this.gunSprite.color = Color.white;

        //this.bulletSprite = bulletPrefabulous.GetComponent<SpriteRenderer>();
        this.bulletSprite.color = Color.white;

        // add something to do bulletprefab in code
        this.bulletSpeed = 20f;

    }

    public override void shoot(GameObject shootingPoint, GameObject bulletPrefabulous)
    {
        GameObject bullet = Instantiate(bulletPrefabulous, shootingPoint.transform.position, shootingPoint.transform.rotation);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        //SHOOT ISN'T BEING PASSED THE bulletSpeed VARIABLE, WHICH IS WHY THE BULLETS WERENT MOVING.
        //EVERYTHING EXCEPT FOR COLOR CHANGE IS WORKING. SO THE PISTOL NEEDS TO BE PASSED A COLOR AND A BULLET SPEED OR SOMEHOW HAVE THOSE VARIABLES DEFINED IN THE SCRIPT, AS LONG AS THEY AREF ACCESSIBLE IN THIS SHOOT METHOD.
        //PSEUDOMOUSE ALSO NEEDS TO BE PASSED SO THAT IT'S SPRITE CHANGE HAVE IT'S COLOR CHANGED

        bulletRB.AddForce(shootingPoint.transform.up * 20f, ForceMode2D.Impulse); //that 20f should instead be the variable bulletSpeed, but bulletSpeed either isn't being passed or has a value of 0f which is why the bullets weren't moving 
                                                                                  //bullet.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f); //this randomizes a color using hue, saturation and value. Too many colors = never getting kills.
                                                                                  //This is why we need a list of colors to limit the amount of colors possible

        //bullet.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)]; 
        //^^^ THIS IS CAUSING AN ERROR, NOT ENTIRELY SURE WHY BUT PROBABLY SOMETHING TO DO WITH THE colors list BEING PASSED FROM THE AWeapon SCRIPT.
            


        //Set the SpriteRenderer to the Color defined by the Sliders
        //int randomColor = Random.Range(0, this.colors.Count);
        //gunSprite.color = colors[randomColor];
        // bulletSprite.color = colors[randomColor];
    }
}
