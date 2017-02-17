using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class Capsule {

	public Vector Position = new Vector(0,8);

	public float Force;
	public float Angle;

	public int Fuel = 1000; 

	public int Shield = 1000;

	public Capsule(float force, float angle) {
		Force = force;
		Angle = angle;

		Position.x = Random.Range (-3f, 3f);
	}



}
