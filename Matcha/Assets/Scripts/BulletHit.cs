using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //prevents bullets from travelling forever which will slow down the game. 30 is an arbitrary number
    [SerializeField] private float maxBulletDistance = 30f;
    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
        if(transform.position.x > maxBulletDistance || transform.position.x < -maxBulletDistance || transform.position.y > maxBulletDistance || transform.position.y < -maxBulletDistance)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision){


        if(collision.gameObject.tag != "Mirror"){
            //Destroys the bullet when it collides with something that has a 2D collider that isn't a mirror
            Destroy(gameObject);
        }

        /*
         *if we want the bullets to bounce off of each other instead of breaking when colliding with each other, use this if statement instead of the one above
         *
        if (collision.gameObject.tag != "Mirror" && collision.gameObject.tag != "Bullet")
        {
            //Destroys the bullet when it collides with something that has a 2D collider that isn't a mirror
            Destroy(gameObject);
        }
        */


    }


}