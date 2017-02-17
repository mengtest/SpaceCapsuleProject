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
		
		for (float i = PosMin.x; i <= PosMax.x ; i += 0.1f) {
			for (float j = PosMin.y; i <= PosMax.y; i += 0.1f) {
				
				if (other.PosMin.x < i < other.PosMax.x && other.PosMin.y < j < other.PosMax.y) {
					return true;
				} else {
					return false;
				}

			}
		}

	}




}
