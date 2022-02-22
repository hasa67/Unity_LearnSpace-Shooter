using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

	public float dodge;
	public float smoothing;
	public float tilt;

	public Vector2 startWait;
	public Vector2 maneuverWait;
	public Vector2 maneuverTime;

	private float currentSpeed;
	private float targetManeuver;
	private Rigidbody rb;

	private CameraShake cameraShake;
	private Vector2 screenSize;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;

		cameraShake = Camera.main.GetComponent<CameraShake> ();
		screenSize = cameraShake.CameraBoundary (0.1f, -0.5f);

		StartCoroutine (Evade ());
	}

	IEnumerator Evade () {
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

		while (true) {
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign(transform.position.x);
			yield return new WaitForSeconds (Random.Range(maneuverTime.x, maneuverTime.y));

			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range(maneuverWait.x, maneuverWait.y));
		}

	}

	void FixedUpdate (){
		float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManeuver, 0, currentSpeed);

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, -screenSize.x, screenSize.x),
			0f,
			Mathf.Clamp(rb.position.z, -screenSize.y, screenSize.y));

		rb.rotation = Quaternion.Euler (0, 0, rb.velocity.x * -tilt);
	}

}
