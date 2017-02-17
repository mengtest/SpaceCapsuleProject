using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class Hitbox {



	public Vector Position;
	public Vector Size;

	public Vector PosMax;
	public Vector PosMin;

	public string Tag;

	// instantiate a hitbox at position, that position is the center of the hitbox. 
	// Hit box defined by Vectors Posmin and PosMax (bottom left and top right).
	public Hitbox(Vector pos, Vector size, string s) {
		Position = pos;
		Tag = s;

		PosMax = pos + (size / 2);
		PosMin = pos - (size / 2);

		Size = size;
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
