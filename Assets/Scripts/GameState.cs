using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class GameState {
	
	public static Vector PlayerPos;

	static public string CheckState() {
		PlayerPos = Capsule.Position;

		if (PlayerPos.x > 7.3f | PlayerPos.x < -7.3f) {
			return "out of bounds";
		} else if (PlayerPos.y <= -9) {
			return "crash";
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
		case "ok":
			go = false;
			break;
		default:
			Debug.Log ("Error : Unknwon message");
			break;
		}

	}

}
