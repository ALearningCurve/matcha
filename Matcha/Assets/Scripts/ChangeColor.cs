using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColor : MonoBehaviour
{
    [SerializeField] private GameObject MATCHAprefab;

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag == "Bullet")
        {
            Color bulletColor = collision.gameObject.GetComponent<SpriteRenderer>().color;

            if (bulletColor == gameObject.GetComponent<SpriteRenderer>().color)
            {
                

                Debug.Log("Hit by same color bullet, MATCHA!");
                GameObject matcha = Instantiate(MATCHAprefab, transform.position + new Vector3(0f, 0f, -1.8f), Quaternion.identity);
                matcha.GetComponent<SpriteRenderer>().color = new Color(bulletColor.r, bulletColor.g, bulletColor.b, 1f);


            }
            else
            {
                Debug.Log("hit by different color");
                gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
        }
    }
    

}
