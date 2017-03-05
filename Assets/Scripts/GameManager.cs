using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[Header ("Objects")]
	public SpriteRenderer PlayerSprite;
	[Space(5)]
	public Text FuelText;
	public Image FuelGauge;
	[Space(5)]
	public Text ShieldText;
	public Image ShieldGauge;


	private Vector3 _TouchPos;
	private Vector3 MousePos;

	[Header ("Capsule physics values")]
	[SerializeField]
	private float _gravity;
	[SerializeField]
	private float _angle;
	[SerializeField]
	private float _force;


	[Header ("Shield & Fuel Values")]
	[SerializeField]
	private float Threshold;
	[SerializeField]
	private float FuelLoss;
	[SerializeField]
	private float ShieldLoss;

	[Header ("UI Text")]
	public Text UIText;


	private Vector Speed = new Vector(0,0);
	private Vector Gravity;

	public Capsule Player;

	private bool GameOver = false; 
	private string State;

	void Start () {
		
		//Vector declarations
		Gravity = Vector.Acceleration(_gravity/10000, -90);
		Player = new Capsule(_force/10000, _angle);

		//UI Text assignation

	}

	void FixedUpdate() {
		
		//GameLoop
		if (!GameOver) {
			CapsuleStateUpdate ();
			DisplayUpdate ();
			StateUpdate ();
		}

	}



	//Update sprites' positions
	void DisplayUpdate() {
		PlayerSprite.transform.position = new Vector2 ( Capsule.Position.x, Capsule.Position.y);
		if (Capsule.Shield >= 0) ShieldText.text = Capsule.Shield.ToString ();
		else ShieldText.text = "0";

		if (Capsule.Fuel >= 0) FuelText.text = Capsule.Fuel.ToString ();
		else FuelText.text = "0";

		ShieldGauge.rectTransform.localScale = new Vector2 ((ShieldGauge.preferredWidth / 1000 * Capsule.Shield)/10, 1);
		FuelGauge.rectTransform.localScale = new Vector2 ((FuelGauge.preferredWidth / 1000 * Capsule.Fuel)/10, 1);
	}

	void StateUpdate() {
		State = GameState.CheckState ();
		GameState.MessageHandler (State, out GameOver);
		UIText.text = GameState.TextHandler (State);
	}

	//Updates Capsule 
	void CapsuleStateUpdate () {

		//Position update using vectors
		Speed += Gravity;
		Capsule.Position += Speed;

		//Accelerates depending on input side and if fuel >0
		if (Capsule.Fuel > 0) {
			switch (InputSide ()) {
			case "left":
				Speed += Vector.Acceleration (Player.Force, Player.Angle);
				Capsule.Fuel -= FuelLoss;
				break;
			case "right":
				Speed += Vector.Acceleration (Player.Force, Player.Angle + (90 - Player.Angle) * 2);
				Capsule.Fuel -= FuelLoss;
				break;
			default:
				break;
			}
		}

		//Heat shield lost if vertical speed is too great
		if (Speed.y < Threshold / 10000) {
			Capsule.Shield -= Mathf.RoundToInt(ShieldLoss * Speed.y * -100);
			PlayerSprite.color = Color.red; 
		} else { 
			PlayerSprite.color = Color.white;
		}

	}



	//Checks for touch/mouse input, returns "left" or "right"
	string InputSide () {
		if (Input.GetKey (KeyCode.Mouse0)) {

			MousePos = Input.mousePosition; 
			MousePos.z = 0;
			MousePos = Camera.main.ScreenToWorldPoint (MousePos);

			if ( MousePos.x > 0) return "left";
			else if ( MousePos.x <= 0) return "right";
		}
		return null;
	}

}
