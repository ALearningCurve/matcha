using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/// <summary>
/// This is simply an approximation of a player controller to test how movement is networked.
/// </summary>
public class NetworkedPlayerScript : NetworkBehaviour
{
    private Rigidbody2D rb;
    private const float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // we only want the client to be able to move their own player
        if (!isLocalPlayer)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;
        Vector2 vect = new Vector2(x, y);
        rb.AddForce(vect);
    }
}
