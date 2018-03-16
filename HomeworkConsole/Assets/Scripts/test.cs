using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	private Camera cam;
	private float speed = .5f;

	static float temp = .0f;

	void Awake () {
		cam = Camera.main.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);

		//cam.backgroundColor = Color.Lerp (Color.blue, Color.green, temp);

		temp += speed * Time.deltaTime;

		if (temp < 1f) {
			cam.backgroundColor = Color.Lerp (Color.blue, Color.green, temp);
		}
	}
}
