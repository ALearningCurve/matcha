using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkedBullet : NetworkBehaviour
{
    public float destroyAfter = 3f;
    public float forceToAdd = 1f;
    public Rigidbody2D rb;

    public override void OnStartServer()
    {
        Invoke(nameof(DestroySelf), destroyAfter);
    }

    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }


    private void Update()
    {
        transform.Translate(new Vector3(0, forceToAdd * Time.deltaTime, 0));
    }

    // ServerCallback makes it so that this callback is only ever called by the server
    // so that the client and the server aren't competing to destroy the bullet as the 
    // client shouldn't be calling NetworkServer.Destroy
    [ServerCallback]
    void OnTriggerEnter(Collider collider)
    {
        DestroySelf();
    }
}
