using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class GameManager : MonoBehaviour {

	public SpriteRenderer PlayerSprite;

	private Vector3 _TouchPos;
	private Vector3 MousePos;

	[SerializeField]
	private float _gravity, _angle, _force;

	public Vector Speed = new Vector(0,0);
	public Vector Gravity;

	public Capsule Player;

	private bool GameOver = false; 
	private string State;

	void Start () {
		
		//Vector declarations
		Gravity = Vector.Acceleration(_gravity/10000, -90);
		Player = new Capsule(_force/10000, _angle);

	}

	//GameLoop
	void FixedUpdate () {
		if (!GameOver) {
			PhysicsUpdate ();
			DisplayUpdate ();
			State = GameState.CheckState ();
			GameState.MessageHandler (State, out GameOver);
		}

	}


	//Update sprites' positions
	void DisplayUpdate() {
		PlayerSprite.transform.position = new Vector2 ( Capsule.Position.x, Capsule.Position.y);
	}

	//Updates Vectors & Positions
	void PhysicsUpdate () {
		Speed += Gravity;
		Capsule.Position += Speed;

		switch (InputSide ()) {
		case "left":
			Speed += Vector.Acceleration (Player.Force, Player.Angle);
			break;
		case "right":
			Speed += Vector.Acceleration (Player.Force, Player.Angle + (90 - Player.Angle) * 2);
			break;
		}
	}

	//Checks for touch/mouse input, returns "left" or "right"
	string InputSide () {
		if (Input.GetKey (KeyCode.Mouse0)) {

			MousePos = Input.mousePosition; 
			MousePos.z = 0;
			MousePos = Camera.main.ScreenToWorldPoint (MousePos);

			if ( MousePos.x > 0) return "left";
			if ( MousePos.x <= 0) return "right";
		}
		return null;
	}

}
