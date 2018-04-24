using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Driftout : MonoBehaviour
{
	public Car car;
	public Transform blocks;

	public Text title;
	public Text finish;
	public Text gameOver;
	public Text time;

	float timer;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (title.enabled) {
			if (Input.GetAxis("Horizontal") != 0) {
				title.enabled = false;
				car.enabled = true;
			}
		}

		if (car && blocks.childCount == 0 && finish.enabled == false) {
			car.enabled = false;
			finish.enabled = true;

			Invoke ("Restart", 5f);
		}

		if (!car && finish.enabled == false && gameOver.enabled == false) {
			gameOver.enabled = true;

			Invoke ("Restart", 3f);
		}

		if (car && car.enabled) {
			var str = "t i m e  " + timer.ToString ("0.0");

			time.text = str.Replace("1", " 1 ");
			timer += Time.deltaTime;
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene ("Main");
	}
}
