using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class Hitbox {



	public Vector Position;
	public Vector Size;



	public string tag;

	public Hitbox(Vector pos, float x, float y, string s) {
		Position = pos;


	}



	public bool CheckCol (Hitbox other) {
		
		for (float i = 0f; i <= other.Size.x; i += 0.1f) {
			for (float j = 0f; i <= other.Size.y; i += 0.1f) {
				if (true){
				}
			}
		}

		return true;

	}
}
