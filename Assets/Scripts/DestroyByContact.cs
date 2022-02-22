using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		if (gameController == null) {
			Debug.Log("The 'Game Controller' object is not found.");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}

		Destroy (other.gameObject);
		Destroy (gameObject);

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		gameController.AddScore (scoreValue);
	}
}
