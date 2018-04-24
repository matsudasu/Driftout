using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Driftout : MonoBehaviour
{
	public Text disp;
	public Car car;
	public Transform blocks;

	bool inGame;
	float timer;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (blocks.childCount == 0) {
			car.enabled = false;
			disp.text = "Finish! " + timer.ToString ("0.00");

			if (Input.anyKeyDown) {
				SceneManager.LoadScene ("Main");
			}

			return;
		}

		if (!car) {
			disp.text = "Game Over";

			if (Input.anyKeyDown) {
				SceneManager.LoadScene ("Main");
			}

			return;
		}

		if (Input.GetAxis("Horizontal") != 0) {
			car.enabled = true;
		}

		if (car.enabled) {
			disp.text = timer.ToString ("0.00");
			timer += Time.deltaTime;
		}
	}
}
