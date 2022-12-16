using UnityEngine;

public class BulletHit : MonoBehaviour
{

    [SerializeField] private GameObject splatPrefab;

    [SerializeField] private SpriteRenderer bulletSpriteRenderer;

    private bool bulletHasBounced = false;

    [SerializeField] private GameObject MATCHAprefab;

    private void createSplat()
    {
        GameObject paintSplat = Instantiate(splatPrefab, transform.position, Quaternion.identity);
        paintSplat.GetComponent<SpriteRenderer>().color = bulletSpriteRenderer.color;
        paintSplat.transform.localScale = gameObject.transform.localScale;
    }
    
    private void createMatcha(Color bulletColor)
    {
        GameObject matcha = Instantiate(MATCHAprefab, transform.position + new Vector3(0f, 0f, -1.8f), Quaternion.identity);
        matcha.GetComponent<SpriteRenderer>().color = new Color(bulletColor.r, bulletColor.g, bulletColor.b, 1f);

    }

    private void OnCollisionEnter2D(Collision2D collision){


        //switch (collision.gameObject.tag)
        //{
        //    case null:
        //        break;

        //    case "Player":
        //        if (bulletHasBounced)
        //        {

        //        }
        //        break;
        //}



        //this below code works in making the shotgun not kill you instantly if you aim up, however if the bullets hit each other, then you can get hit by one of the bullets instantly when you shoot up
        //this has an issue where if a bullet hit's a player before bouncing off of something, the bullet will bounce off of the player. this will not be good for multiplayer
        /*if(collision.gameObject.tag != null && collision.gameObject.tag != "Player")
        {
            bulletHasBounced = true;
        }*/

        if (collision.gameObject.tag == "Mirror")
        {
            bulletHasBounced = true;
        }


        if (collision.gameObject.tag == "Player" && bulletHasBounced == true)
        {
            Color bulletColor = bulletSpriteRenderer.color;

            if (bulletColor == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {


                Debug.Log("Hit by same color bullet, MATCHA!");
                createMatcha(bulletColor);


            }
            else
            {
                Debug.Log("hit by different color");
                collision.gameObject.GetComponent<SpriteRenderer>().color = bulletSpriteRenderer.color;
            }
            createSplat();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {

            Color bulletColor = bulletSpriteRenderer.color;


            if (bulletColor == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {


                Debug.Log("Hit by same color bullet, MATCHA!");
                createMatcha(bulletColor);

                collision.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("hit by different color");
                collision.gameObject.GetComponent<SpriteRenderer>().color = bulletSpriteRenderer.color;
            }
            createSplat();
            Destroy(gameObject);
        }




        if (collision.gameObject.tag == "Ground")
        {
            createSplat();
            Destroy(gameObject);
        }


        /*we shoot the bullet
         * 
         * if the bullet hits the player and the bullet has not bounced off of another object, the bullet does not kill
         * 
         * if the bullet hits the player and has bounced off of another object, the bullet does kill
         * 
         * if the bullet hits an object that has the ground tag, the bullet will be destroyed
         * 
         * 
         * fuck
         * 
         * the change color script needs to be changed too for this to work
         * god diddly damm it
         * 
         * 
         

        if (collision.gameObject.tag != "Player")
        {
            bulletHasBounced = true;
        }

        if(collision.gameObject.tag != "Mirror" && collision.gameObject.tag != "Bullet" || collision.gameObject.tag == "Player" && bulletHasBounced)
        {

            
            GameObject paintSplat = Instantiate(splatPrefab, transform.position, Quaternion.identity);
            paintSplat.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            paintSplat.transform.localScale = gameObject.transform.localScale;
            
            //Destroys the bullet when it collides with something that has a 2D collider that isn't a mirror or a bullet
            Destroy(gameObject);

        }
        */
    }

}