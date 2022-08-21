using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{
    
    protected float bulletSpeed = 20f;

    protected List<Color> colors = new List<Color>(new [] { 
        new Color(1f, 1f, 1f, 1f), 
        new Color(216f / 255f, 94f / 255f, 0f, 1f), 
        new Color(204f / 255f, 121f / 255f, 167f / 255f, 1f),
        new Color(0f, 114f / 255f, 178f / 255f, 1f), 
        new Color(240f / 255f, 228f / 255f, 66f / 255f, 1f) });
    
    public Shotgun() {}
    
    
    public void shoot(GameObject shootingPoint, GameObject bulletPrefab, Color color)
    {
        GameObject bullet1 = Instantiate(bulletPrefab, shootingPoint.transform.position 
                                                       + new Vector3(0f, 1f, 0f), shootingPoint.transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, shootingPoint.transform.position 
                                                       + new Vector3(0f, 0f, 0f), shootingPoint.transform.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, shootingPoint.transform.position 
                                                       + new Vector3(0f, -1f, 0f), shootingPoint.transform.rotation);
        
        Rigidbody2D bulletRB1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D bulletRB2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D bulletRB3 = bullet3.GetComponent<Rigidbody2D>();
        
        bulletRB1.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
        bulletRB2.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
        bulletRB3.AddForce(shootingPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
        
        bullet1.GetComponent<SpriteRenderer>().color = color; 
        bullet2.GetComponent<SpriteRenderer>().color = color; 
        bullet3.GetComponent<SpriteRenderer>().color = color; 
    }

    public void reload()
    {
        throw new System.NotImplementedException();
    }
}
