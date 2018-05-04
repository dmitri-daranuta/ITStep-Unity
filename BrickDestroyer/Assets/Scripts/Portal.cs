using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public Transform portalExit;

	void OnTriggerEnter2D(Collider2D other) {
		Ball b = other.GetComponent<Ball> ();

		if (other.tag == "Ball") {
			if (b.portal == true) {
				b.enterPortal = gameObject.name;
				b.portal = false;
				other.transform.position = new Vector2 (portalExit.position.x, portalExit.position.y);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.GetComponent<Ball>().enterPortal != gameObject.name) {
			other.GetComponent<Ball> ().portal = true;	
		}
	}
}
