using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class Capsule {

	public Capsule(float force, float angle) {
		Force = force;
		Angle = angle;
	}

	public float Force;
	public float Angle;

	public Vector Position = new Vector(0,8);


	public int Fuel = 1000; 

	public int Shield = 1000;


}
