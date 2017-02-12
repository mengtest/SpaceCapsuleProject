using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject Player;
	public Rigidbody2D PlayerRB;
	public float ForceX;
	public float ForceY;

	private Vector3 _TouchPos;
	private Vector3 MousePos;


	void Start () {
		PlayerRB = Player.GetComponent<Rigidbody2D> ();
	}
	

	void Update () {

		if (Input.GetKey (KeyCode.Mouse0)) {

			MousePos = Input.mousePosition; 
			MousePos.z = 0;
			MousePos = Camera.main.ScreenToWorldPoint (MousePos);

			if ( MousePos.x > 0) {
				PlayerRB.AddRelativeForce (new Vector2 (ForceX, ForceY));
			}
			if (MousePos.x <= 0) {
				PlayerRB.AddRelativeForce (new Vector2 (-ForceX, ForceY));
			}

		}

		/*//touch controls
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			
			_TouchPos = Touch.position; 
			_TouchPos.z = 0;
			_TouchPos = Camera.main.ScreenToWorldPoint (_TouchPos);

			if ( Touch.position.x > 0) {
				PlayerRB.AddRelativeForce (new Vector2 (ForceX, ForceY));
			}
			if ( Touch.position.x <= 0) {
				PlayerRB.AddRelativeForce (new Vector2 (-ForceX, ForceY));
			}

		}*/


	}

}
