using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class NetworkData : NetworkBehaviour {
	
	
	// Use this for initialization
	public GameObject PlayerPrefab;
    public Camera cam;

	void Start () {

//        cam = GetComponent<Camera>();
        //		Vector3 spawnPosition = new Vector3(210, 2, 168);
        if (isLocalPlayer) {
            Debug.Log(GetType().Name + " - Start() isLocalPlayer - " + gameObject.name);
            GameObject.Find("Main Camera").gameObject.transform.parent = transform;
        } else {
            cam.enabled = false;
            return;
        }
		
//		Instantiate(PlayerPrefab,spawnPosition,transform.rotation);
	}

    void Awake()
    {
        cam.enabled = false;
    }


    // Update is called once per frame
    void Update () {
    }
    
    public override void OnStartLocalPlayer() {
        cam.enabled = true;
//        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
        if (isLocalPlayer)
        {
            Debug.Log(GetType().Name + " - OnStartLocalPlayer() isLocalPlayer - " + gameObject.name);
        }
        else
        {
            Debug.Log(GetType().Name + " - OnStartLocalPlayer() !isLocalPlayer - " + gameObject.name);
        }
    }

}
