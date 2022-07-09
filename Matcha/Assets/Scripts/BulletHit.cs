using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bullet hit something");
        //Destroys the bullet when it collides with something that has a 2D collider
        Destroy(gameObject);


        //down here vvv you would add the necessary code for dealing damage and whatnot

    }
}
