using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	public GameObject ballPrefab;
	public float interval = 8f;

	Renderer r;
	Collider col;

	float timer;

	// Use this for initialization
	void Start ()
	{
		r = GetComponent<Renderer> ();
		col = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if (timer > interval) {
			r.enabled = true;
			col.enabled = true;
		}
	}
		
	void OnTriggerEnter (Collider c)
	{
		Instantiate (ballPrefab, transform.position, c.transform.rotation);
		r.enabled = false;
		col.enabled = false;
		timer = 0;
	}
}
