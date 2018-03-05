using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleController : MonoBehaviour {

	public string username;

	private GameObject emptyChild;
	private GameObject parent;
	private Camera cam;
	private Color defaultColor;
	private bool rainbow = false;
	private bool emptyObj = false;

	void Start () {
		parent = GameObject.FindWithTag ("MainCamera");
		cam = parent.GetComponent<Camera> ();
		defaultColor = cam.backgroundColor;
		if (string.IsNullOrEmpty(username)) {
			username = "Name is empty!";
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log (username);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log ("\"" + username + "\"");
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			cam.backgroundColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			rainbow = !rainbow;
		}

		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			cam.backgroundColor = defaultColor;
		}

		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			emptyChild = new GameObject("Object");
			emptyChild.transform.parent = parent.transform;

			Component[] comps = parent.GetComponents(typeof(Component));
			foreach (Component com in comps) {
				if (com.GetType () != typeof(Transform) && com.GetType() != typeof(AudioListener)) {
					emptyChild.AddComponent (com.GetType ());
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			emptyObj = !emptyObj;
		}

		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			Application.Quit ();
		}

		if (emptyObj) {
			new GameObject("I am an empty object");
			Debug.Log ("Created empty object");
		}

		if (rainbow) {
			cam.backgroundColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		}
	}
}
