using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag == "Bullet")
        {
            if(collision.gameObject.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color)
            {
                Debug.Log("Hit by same color bullet, MATCHA!");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("hit by different color");
                gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            }
        }
    }
}
