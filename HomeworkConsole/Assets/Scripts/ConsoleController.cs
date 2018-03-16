using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour {

	public string username;
	public float changeSpeed = .5f;
	public Text textMenu;
	public Text textHelp;

	private GameObject emptyChild;
	private GameObject parent;
	private Camera cam;
	private Color defaultColor;
	private bool rainbow = false;
	private bool emptyObj = false;
	private bool pingPong = false;
	private bool lerp = false;
	static float tempTime = 0f;

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
			textMenu.color = Color.white;
			textHelp.color = Color.white;
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

		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			lerp = !lerp;
			if (tempTime > 1f) {
				tempTime = 0f;
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			pingPong = !pingPong;
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

		if (lerp) {
			tempTime += changeSpeed * Time.deltaTime;

			if (tempTime < 1f) {
				cam.backgroundColor = Color.Lerp (Color.black, Color.white, tempTime);
				textMenu.color = Color.Lerp (Color.white, Color.black, tempTime);
				textHelp.color = Color.Lerp (Color.white, Color.black, tempTime);
			} else {
				lerp = !lerp;
			}
		}

		if (pingPong) {
			cam.backgroundColor = Color.Lerp (Color.blue, Color.green, Mathf.PingPong(Time.time, 1));
		}
	}
}
