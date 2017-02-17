using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class GameManager : MonoBehaviour {

	public SpriteRenderer PlayerSprite;

	private Vector3 _TouchPos;
	private Vector3 MousePos;

	public float gravity;

	public float Angle;
	public float Force;

	public Vector Speed = new Vector(0,0);
	public Vector Gravity;

	public Capsule Player;

	void Start () {
		Gravity = Vector.Acceleration(gravity/10000, -90);
		Player = new Capsule(Force/10000, Angle);
	}


	void FixedUpdate () {
		Speed += Gravity;


		if (Input.GetKey (KeyCode.Mouse0)) {

			MousePos = Input.mousePosition; 
			MousePos.z = 0;
			MousePos = Camera.main.ScreenToWorldPoint (MousePos);

			if ( MousePos.x > 0) {
				Speed += Vector.Acceleration (Player.Force, Player.Angle);
			}

			if (MousePos.x <= 0) {
				Speed += Vector.Acceleration (Player.Force, Player.Angle + (90 - Player.Angle) * 2);
			}
		}
		Player.Position += Speed;

		PlayerSprite.transform.position = new Vector2 ( Player.Position.x, Player.Position.y);
	}




}
