using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //prevents bullets from travelling forever which will slow down the game. 30 is an arbitrary number
    [SerializeField] private float maxBulletDistance = 30f;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > maxBulletDistance || transform.position.x < -maxBulletDistance || transform.position.y > maxBulletDistance || transform.position.y < -maxBulletDistance)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroys the bullet when it collides with something that has a 2D collider
        Destroy(gameObject);
    }

    
}