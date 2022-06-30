using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

/// <summary>
/// This is simply an approximation of a player controller to test how movement is networked.
/// </summary>
public class NetworkedPlayerScript : NetworkBehaviour
{
    private const float speed = 5f;
    public TextMesh playerNameText;
    public GameObject floatingInfo;
    public Rigidbody2D rb;
    public GameObject projectilePrefab;
    public Transform projectileMount;

    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;

  
    void OnNameChanged(string _old, string _new) {
        playerNameText.text = playerName;
    }


    public override void OnStartLocalPlayer()
    {   
        base.OnStartClient();
        SetupPlayer("Player");
    }

    [Command]
    public void SetupPlayer(string name)
    {
        // Make these changes on the server by calling the command,
        // this way the changes will be networked by the server.
        playerName = name;
    }


    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    // this is called on the server
    [Command]
    void CmdFire()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, projectileMount.rotation);
        NetworkServer.Spawn(projectile);
        RpcOnFire();
    }

    // this is called on the tank that fired for all observers
    [ClientRpc]
    void RpcOnFire()
    {
// animator.SetTrigger("Shoot");
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
        //  transform.Translate(new Vector3(x, y, 0));
        rb.AddForce(new Vector2(x, y));
    }

    void HandleShooting()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }
}
