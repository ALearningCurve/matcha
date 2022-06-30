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
    private const float speed = 10f;
    public Text playerNameText;
    public GameObject floatingInfo;

    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;

  
    private void OnNameChanged(string _old, string _new) {
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
    }

    private void HandleMovement()
    {
        // we only want the client to be able to move their own player
        if (!isLocalPlayer)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(new Vector3(x, y, 0));
    }
}
