using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePortal : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ball") {
			GameObject newBall =  Instantiate (other.gameObject, other.transform.position, Quaternion.identity) as GameObject;
			Rigidbody2D	rb = newBall.GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector2 (Random.Range(-5f, 5f), Random.Range(-5f, 5f));
		}
	}
}
