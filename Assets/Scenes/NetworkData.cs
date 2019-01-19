using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class NetworkData : NetworkBehaviour {
	
	
	// Use this for initialization
	public GameObject PlayerPrefab;
	void Start () {
		
//		Vector3 spawnPosition = new Vector3(210, 2, 168);
		if (isLocalPlayer == false) {
		return;
		}
		
//		Instantiate(PlayerPrefab,spawnPosition,transform.rotation);
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}

}
