using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	private float shotTimer = 0f;
	public float shotCooldown;

	private Rigidbody rb;
	private Vector3 touchPosition;
	private float zOffset = 2f;

	private CameraShake cameraShake;
	private Vector2 screenSize;

	void Start(){
		rb = GetComponent<Rigidbody> ();

		cameraShake = Camera.main.GetComponent<CameraShake> ();
		screenSize = cameraShake.CameraBoundary (0.1f, 0.1f);
	}

	void Update(){
		shotTimer -= Time.deltaTime;

		if(Input.GetButton("Fire1") && shotTimer <= 0){
			Instantiate(shot, shotSpawn.position, Quaternion.identity);
			shotTimer = shotCooldown;
			GetComponent<AudioSource> ().Play ();
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		rb.velocity = movement * moveSpeed * 3;

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			touchPosition = Camera.main.ScreenToWorldPoint (touch.position);
			touchPosition.z += zOffset;
			touchPosition.y = 0;
			movement = (touchPosition - transform.position);
			rb.velocity = movement * moveSpeed;

			if (touch.phase == TouchPhase.Ended) {
				rb.velocity = Vector2.zero;
			}
		}
			
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, -screenSize.x, screenSize.x),
			0,
			Mathf.Clamp(rb.position.z, -screenSize.y, screenSize.y));

		rb.rotation = Quaternion.Euler (0, 0, rb.velocity.x * -tilt);
	}
}
