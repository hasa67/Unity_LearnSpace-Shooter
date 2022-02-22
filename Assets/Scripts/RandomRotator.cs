using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	void Start () {
		Rigidbody sr = GetComponent<Rigidbody> ();
		sr.angularVelocity = Random.insideUnitCircle * tumble;
	}

}
