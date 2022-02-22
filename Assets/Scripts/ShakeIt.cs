using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeIt : MonoBehaviour {

	public float shakeDuration = 0.1f;
	public float shakeMagnitude = 0.1f;

	private CameraShake cameraShake;

	void Start () {
		cameraShake = Camera.main.GetComponent<CameraShake> ();
		StartCoroutine (cameraShake.Shake (shakeDuration, shakeMagnitude));
	}
}
