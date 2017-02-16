using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorEngine {

	public struct Vector {
		public float x;
		public float y;
		public Vector(float x, float y) {
			this.x = x;
			this.y = y;
		}

		public Vector Acceleration(float force, float angle) {
			angle = angle * Mathf.Deg2Rad;
			float x = Mathf.Cos (angle) * force;
			float y = Mathf.Sin (angle) * force;

			return new Vector (x, y);

		}

		public static Vector operator+ (Vector a, Vector b) { 
			float resX = a.x + b.x;
			float resY = a.y + b.y;
			return new Vector (resX, resY);
		}

		public static Vector operator- (Vector a, Vector b) { 
			float resX = a.x - b.x;
			float resY = a.y - b.y;
			return new Vector (resX, resY);
		}


	}
}
