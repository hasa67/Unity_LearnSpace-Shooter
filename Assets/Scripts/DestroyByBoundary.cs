using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	private CameraShake cameraShake;
	private Vector2 screenSize;

	void Start ()
	{
		cameraShake = Camera.main.GetComponent<CameraShake> ();
		screenSize = cameraShake.CameraBoundary (-.5f, 0f);

		transform.localScale = new Vector3 (2 * screenSize.x, 1, 2 * screenSize.y);
	}

	void OnTriggerExit (Collider other)
	{
		Destroy (other.gameObject);
	}
}
