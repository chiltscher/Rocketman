using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


    Rigidbody rigidbody;
    AudioSource engineSound;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rcsThrust = 150f;
    [SerializeField] float adjustThrust = .5f;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
        ControlJets();
    }

    private void ControlJets()
    {
        // Control jets
        if (Input.GetKey(KeyCode.Q))
        {
            rigidbody.AddRelativeForce(Vector3.right * adjustThrust);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rigidbody.AddRelativeForce(Vector3.left * adjustThrust);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                {
                    print("All right!");
                    break;
                }
            case "Obstacle":
                {
                    print("Booooom");
                    break;
                }
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true;
        // framerate dependent
        float rotationSpeed = rcsThrust * Time.deltaTime;


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        rigidbody.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
            engineSound.pitch = 2.0F;
        }
        else
        {
            engineSound.pitch = 1.0F;
        }
    }
}
