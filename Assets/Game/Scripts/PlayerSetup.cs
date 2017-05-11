﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    public Behaviour[] componentsToDisable;

    private void Start()
    {
        if(!isLocalPlayer)
        {
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        string netId = GetComponent<NetworkIdentity>().netId.ToString();
        
        GameManager.RegisterPlayer(netId, this.gameObject);
    }

    private void OnDisable()
    {
        GameManager.UnRegisterPlayer(transform.name);
    }
}
