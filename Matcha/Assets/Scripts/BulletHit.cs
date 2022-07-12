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
        //Debug.Log("bullet hit something");
        //Destroys the bullet when it collides with something that has a 2D collider
        Destroy(gameObject);
        Explode();


        //down here vvv you would add the necessary code for dealing damage and whatnot
        //or make a method that handles player health damage similar to how void Explode() handles explosion forces

    }


    //I stole all of this code from here..
    //this code makes it so that it an "explosion force" is added to the rigidbody of any object that the bullet collides with.
    //This can be used to make pseudo rocket jumping (will need adjustments for this to work)
    //, or we can make it so that this only affects objects and not players
    Collider2D[] inExplosionRadius = null;
    [SerializeField] private float explosionForce = 100f;
    [SerializeField] private float blastRadius = 5f;



    void Explode()
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D col in inExplosionRadius)
        {
            Rigidbody2D colRB = col.GetComponent<Rigidbody2D>();

            //this will make it not affect players (as much)
            //if (colRB != null && colRB.gameObject.tag != "Player")
            if (colRB != null)
            {
                Vector2 distanceVector = col.transform.position - transform.position;

                if (distanceVector.magnitude > 0)
                {
                    //so you will not get NaN error, a nice tip is to not devide by 0 :)
                    float finalExplosionForce = explosionForce / distanceVector.magnitude;
                    colRB.AddForce(distanceVector.normalized * finalExplosionForce);
                }
            }
        }

    }


    //draw gizmos
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }

    //... to here
}