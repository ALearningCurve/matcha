using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //prevents bullets from travelling forever which will slow down the game. 30 is an arbitrary number
    [SerializeField] private float maxBulletDistance = 30f;

    void Update()
    {
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
        if(transform.position.x > maxBulletDistance || transform.position.x < -maxBulletDistance || transform.position.y > maxBulletDistance || transform.position.y < -maxBulletDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.tag != "Mirror" && collision.gameObject.tag != "Bullet"){
            //Destroys the bullet when it collides with something that has a 2D collider that isn't a mirror
            Destroy(gameObject);
        }
    }

}