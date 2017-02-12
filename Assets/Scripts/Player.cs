using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Random start x
	void Start () {
		transform.Translate (new Vector2 (Random.Range(-3,3) , 0));
	}
	
	// Collision hanlder
	void OnTrigger2DEnter (Collider2D other) {
		if (other.tag == "Goal") {

		} else if (other.tag == "Ground") {

		}
	}
}
