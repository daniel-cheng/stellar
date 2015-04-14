using UnityEngine;
using System.Collections.Generic;

public class TurretAim : MonoBehaviour {

	//object that will be moving
	public Transform turret;
	//object that will be aimed at
	public Transform player;

	// Use this for initialization
	void Start () {
        player = NetworkManager.player.transform;
        EventNotifier.OnNetworkStateChange += OnNetworkStateChange;
	}
	
	// Update is called once per frame
	void Update () {
		turret.transform.LookAt(player.position);
	}

    void OnNetworkStateChange()
    {
        player = NetworkManager.player.transform;
    }
}
