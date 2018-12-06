using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;
    AudioSource engineSound;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);
            engineSound.pitch = 2.0F;

        } else
        {
            engineSound.pitch = 1.0F;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back);
        }
        // Steuerdüsen
        if(Input.GetKey(KeyCode.Q))
        {
            rigidbody.AddRelativeForce(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rigidbody.AddRelativeForce(Vector3.right);
        }
    }
}
