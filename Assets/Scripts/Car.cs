using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	public WheelCollider [] front, rear;

	public float maxSteerAngle = 30f;
	public float maxMotorTorque = 500f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		var horizontalInput = Input.GetAxis ("Horizontal");

		var steering = maxSteerAngle * horizontalInput;
		var motor = maxMotorTorque - (maxMotorTorque * Mathf.Abs(horizontalInput) * 0.5f);

		foreach (var w in front) {
			w.steerAngle = steering;
			w.motorTorque = motor * 0.75f;
		}

		foreach (var w in rear) {
			w.motorTorque = motor;
		}
	}

	void OnCollisionEnter (Collision c)
	{
		Destroy (gameObject);
	}
}
