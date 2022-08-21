using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{

    protected float bulletSpeed = 20f;

    protected List<Color> colors = new List<Color>(new [] { 
        new Color(1f, 1f, 1f, 1f), 
        new Color(216f / 255f, 94f / 255f, 0f, 1f), 
        new Color(204f / 255f, 121f / 255f, 167f / 255f, 1f),
        new Color(0f, 114f / 255f, 178f / 255f, 1f), 
        new Color(240f / 255f, 228f / 255f, 66f / 255f, 1f) });

    public Pistol()
    {
    }

    public void shoot(GameObject shootingPoint, GameObject bulletPrefabulous, Color color)
    {
        GameObject bullet = Instantiate(bulletPrefabulous, shootingPoint.transform.position, shootingPoint.transform.rotation);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        //SHOOT ISN'T BEING PASSED THE bulletSpeed VARIABLE, WHICH IS WHY THE BULLETS WERENT MOVING.
        //EVERYTHING EXCEPT FOR COLOR CHANGE IS WORKING. SO THE PISTOL NEEDS TO BE PASSED A COLOR AND A BULLET SPEED OR SOMEHOW HAVE THOSE VARIABLES DEFINED IN THE SCRIPT, AS LONG AS THEY AREF ACCESSIBLE IN THIS SHOOT METHOD.
        //PSEUDOMOUSE ALSO NEEDS TO BE PASSED SO THAT IT'S SPRITE CHANGE HAVE IT'S COLOR CHANGED

        bulletRB.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse); //that 20f should instead be the variable bulletSpeed, but bulletSpeed either isn't being passed or has a value of 0f which is why the bullets weren't moving 
                                                                                  //bullet.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f); //this randomizes a color using hue, saturation and value. Too many colors = never getting kills.
                                                                                  //This is why we need a list of colors to limit the amount of colors possible

        bullet.GetComponent<SpriteRenderer>().color = color; 
        //^^^ THIS IS CAUSING AN ERROR, NOT ENTIRELY SURE WHY BUT PROBABLY SOMETHING TO DO WITH THE colors list BEING PASSED FROM THE AWeapon SCRIPT.
            
        
    }
    
        
    

    public void reload()
    {
        throw new System.NotImplementedException();
    }
}
