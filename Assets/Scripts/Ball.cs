using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float force = 10f;

	Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * force, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rb.IsSleeping()) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter (Collision c)
	{
		rb.AddForce (-Vector3.forward);

		if (c.gameObject.tag == "BottomWall") {
			Destroy (gameObject);
		}
	}
}
