using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	private Vector3 orignalPosition;

	private float heightOrtho;
	private float widthOrtho;

	void Start(){
		orignalPosition = transform.position;

//		heightOrtho = Camera.main.orthographicSize;
//		widthOrtho = (float)Screen.width / (float)Screen.height * heightOrtho;
	}


	public IEnumerator Shake(float duration, float magnitude)
	{
		float elapsed = 0f;

		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float z = Random.Range(-1f, 1f) * magnitude;

			transform.position = orignalPosition + new Vector3(x, 0f, z);
			elapsed += Time.deltaTime;
			yield return null;
		}
		transform.position = orignalPosition;
	}

	public Vector2 CameraBoundary (float xOffset, float yOffset)
	{
		heightOrtho = Camera.main.orthographicSize;
		widthOrtho = (float)Screen.width / (float)Screen.height * heightOrtho;

		Vector2 screenSize = new Vector2 (widthOrtho * (1 - xOffset), heightOrtho * (1 - yOffset));
		return screenSize;
	}
		
}