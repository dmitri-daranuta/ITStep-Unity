using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HW2 : MonoBehaviour {

	[Range(0.001f, 0.6f)]
	public float speed = .2f;
	[SerializeField]
	private bool exitOnQuit = true;

	private Camera cam;
	private bool changeColor = false;
	private Color newColor;
	private float tempTime = 0f;

	void Awake () {
		cam = GameObject.FindWithTag ("MainCamera").GetComponent<Camera> ();
	}

	void Update () {
		if (changeColor) {
			tempTime += speed * Time.deltaTime;

			if (tempTime < 1f) {
				cam.backgroundColor = Color.Lerp (cam.backgroundColor, newColor, tempTime);
			} else {
				changeColor = false;
			}
		}
	}

	public void ChangeColor(string color) {
		switch (color) {
		case "white":
			newColor = Color.white;
			break;
		case "red":
			newColor = Color.red;
			break;
		}
		changeColor = true;
		tempTime = 0f;
	}

	public void Quit() {
		if (exitOnQuit) {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif

			Application.Quit ();
		}
	}
}
