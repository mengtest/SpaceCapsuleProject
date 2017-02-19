using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorEngine;

public class Capsule {

	public static Vector Position = new Vector(0,8);

	public float Force { get; }
	public float Angle { get; }

	public static float Fuel = 1000;
	public static float Shield = 1000; 
	public string boule = "dat ass";

	public Capsule(float force, float angle) {
		Force = force;
		Angle = angle;

		Position.x = Random.Range (-3f, 3f);
		Debug.Log (boule);
	}



}
