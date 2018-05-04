using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	float speed = 20f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// What is the player doing with the controls?
		Vector3 move = new Vector3(Input.GetAxis("Mouse X"), 0, 0);

		// Update the bat position each frame
		transform.position += move * speed * Time.deltaTime;

	}
}
