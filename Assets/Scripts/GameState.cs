using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;
using UnityEngine.UI;


public class GameState {
	
	public static Vector PlayerPos;

	static public string CheckState() {
		PlayerPos = Capsule.Position;

		if (PlayerPos.x > 7.3f | PlayerPos.x < -7.3f) {
			return "out of bounds";
		} else if (PlayerPos.y <= -8.8 && PlayerPos.x < -0.5 && PlayerPos.x > 0.5 ) {
			return "crash";
		} else if (Capsule.Shield <= 0) {
			return "no shield";
		} else if (PlayerPos.x > -0.5 && PlayerPos.x < 0.5 && PlayerPos.y <= -8.8){
			return "win";
		} else {
			return "ok";
		}

	}

	static public void MessageHandler (string message, out bool go) {
		
		go = false;

		switch (message) {
		case "out of bounds":
			go = true;
			break;
		case "crash":
			go = true;
			break;
		case "no shield":
			go = true;
			break;
		case "win":
			go = true;
			break;
		case "ok":
			go = false;
			break;
		default:
			Debug.Log ("Error : Unknwon message");
			break;
		}

	}

	static public string TextHandler (string message) {

		string t = "";

		switch (message) {
		case "out of bounds":
			t = "Your capsule was lost in space.";
			break;
		case "crash":
			t = "Your capsule crashed.";
			break;
		case "no shield":
			t = "Your capsule burned down.";
			break;
		case "win":
			t = "You managed to land! Well done!";
			break;
		case "ok":
			t = "";
			break;
		default:
			Debug.Log ("Error : Unknwon message");
			break;
		}

		return t;
	}

}
