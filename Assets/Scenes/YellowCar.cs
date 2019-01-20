using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class YellowCar : NetworkBehaviour {

    public WheelCollider Rear_Right_Wheel;
    public WheelCollider Rear_Left_Wheel;
    public WheelCollider Front_Right_Wheel;
    public WheelCollider Front_Left_Wheel;

    public GameObject RR;
    public GameObject RL;
    public GameObject FR;
    public GameObject FL;

    public float topSpeed = 500f;
    public float maxTorque = 100000f;
    public float maxSteerAngle = 45f;
    public float currentSpeed;
    public float maxBrakeTorque = 10000;

    private float Forward;
    private float Turn;
    private float Brake;

    public Camera mainCamera;
    public Transform playerTransform;
    public int depth = -20;



    void Start () {

        // IF I'M THE PLAYER, STOP HERE (DON'T TURN MY OWN CAMERA OFF)
        if (isLocalPlayer)
        {
            this.transform.GetChild(1).gameObject.GetComponent<Camera>().enabled = true;
            return;
        }
        else
        {
            this.transform.GetChild(1).gameObject.GetComponent<Camera>().enabled = false;
        }

        // DISABLE CAMERA AND CONTROLS HERE (BECAUSE THEY ARE NOT ME)
       // mainCamera.enabled = false;
       // GameObject.Find("Main Camera").gameObject.transform.parent = transform;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");

        Front_Right_Wheel.steerAngle = maxSteerAngle * Turn;
        Front_Left_Wheel.steerAngle = maxSteerAngle * Turn;

        //currentSpeed = 2 * 22 / 7 * Rear_Left_Wheel.radius * Rear_Left_Wheel.rpm * 60 / 1000;

       // if(currentSpeed < topSpeed)
       // {
           Rear_Left_Wheel.motorTorque = maxTorque * Forward;
           Rear_Right_Wheel.motorTorque = maxTorque * Forward;
           Front_Left_Wheel.motorTorque = maxTorque * Forward;
           Front_Right_Wheel.motorTorque = maxTorque * Forward;
        // }

        Rear_Left_Wheel.brakeTorque = maxBrakeTorque * Brake;
        Rear_Right_Wheel.brakeTorque = maxBrakeTorque * Brake;
        Front_Left_Wheel.brakeTorque = maxBrakeTorque * Brake;
        Front_Right_Wheel.brakeTorque = maxBrakeTorque * Brake;
    }

    void Update()
    {
        Quaternion flq;
        Vector3 flv;
        Front_Left_Wheel.GetWorldPose(out flv, out flq);
        FL.transform.position = flv;
        FL.transform.rotation = flq;

        Quaternion rlq;
        Vector3 rlv;
        Rear_Left_Wheel.GetWorldPose(out rlv, out rlq);
        RL.transform.position = rlv;
        RL.transform.rotation = rlq;

        Quaternion frq;
        Vector3 frv;
        Front_Right_Wheel.GetWorldPose(out frv, out frq);
        FR.transform.position = frv;
        FR.transform.rotation = frq;

        Quaternion rrq;
        Vector3 rrv;
        Rear_Right_Wheel.GetWorldPose(out rrv, out rrq);
        RR.transform.position = rrv;
        RR.transform.rotation = rrq;

        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 10, depth);
        }

    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }

    }

