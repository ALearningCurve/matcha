using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MatchaNetworkManager : NetworkManager
{

    public override void OnStartServer()
    {
        Debug.Log("Started server");
        base.OnStartServer();
    }

    public override void OnStopServer()
    {
        Debug.Log("Server Stopped");
        base.OnStopServer();
    }

    [System.Obsolete]
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client connected");
        base.OnClientConnect();
    }

    public override void OnClientDisconnect()
    {
        Debug.Log("Client disconnected");
        base.OnClientDisconnect();
    }
}
