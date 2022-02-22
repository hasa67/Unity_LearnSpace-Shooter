using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

//	private Renderer rend;
	public float scrollSpeed = .01f;
	public float tileSizeZ = 30f;

	private Vector3 startPosition;

	void Start () {
//		rend = GetComponent<Renderer>();
		startPosition = transform.position;
	}

	void Update () {
//		rend.material.SetTextureOffset ("_MainTex", new Vector2 (0, Time.time * scrollSpeed));

		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;

	}
}
