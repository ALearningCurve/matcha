using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DestroysSelfAnimation : NetworkBehaviour
{
    void DestroySelf()
    {
        NetworkManager.Destroy(gameObject);
    }

    public override void OnStartServer()
    {
        float timeAlive = this.GetComponent<ParticleSystem>().main.duration;
        base.OnStartServer();
        Invoke(nameof(DestroySelf), timeAlive);
    }
}
