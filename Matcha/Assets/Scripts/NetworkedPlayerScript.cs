using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is simply an approximation of a player controller to test how movement is networked.
/// </summary>
public class NetworkedPlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private const int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, speed));
        }        
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-1 * speed,0));

        }
        else if (Input.GetKey(KeyCode.S))
        {
            // nothing lol
        }        
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(speed,0));

        }
    }
}
