using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.tag == "Bullet")
        {
            if(collision.gameObject.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color)
            {
                Debug.Log("Hit by same color bullet, MATCHA!");
            }
            else
            {
                Debug.Log("hit by different color");
                gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
        }
    }
}
