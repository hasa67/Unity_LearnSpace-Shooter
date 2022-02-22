using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public int hazardCount;
	public float spawnWait;
	public float waveWait;
	public float startWait;

	public Text scoreText;
	private int score;
	public GameObject restartPanel;

	private CameraShake cameraShake;
	private Vector2 screenSize;

	void Start () {
		score = 0;
		UpdateScore ();

		cameraShake = Camera.main.GetComponent<CameraShake> ();
		screenSize = cameraShake.CameraBoundary (0.1f, -0.2f);

		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player") == null) {
			restartPanel.SetActive (true);

			if(Input.GetKey(KeyCode.R)){
				RestartScene ();
			}
		}
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-screenSize.x, screenSize.x), 0, screenSize.y);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
		}
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int scoreValue){
		score += scoreValue;
		UpdateScore ();
	}

	public void RestartScene () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
