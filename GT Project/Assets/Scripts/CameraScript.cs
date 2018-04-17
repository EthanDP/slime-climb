using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float speed;
	public bool playerAlive = true;

	Transform playerPos;
	float startY;

	void Start () {
		startY = transform.position.y;
	}

	void LateUpdate () {
		if (playerAlive == true) {
			playerPos = GameObject.FindGameObjectWithTag("Player").transform;
			transform.position = Vector3.Lerp (transform.position, new Vector3 (0, playerPos.position.y, -10), speed);
		} else if (playerAlive == false && transform.position.y >= startY) {
			Vector3.Lerp (transform.position, new Vector3 (0, startY, -10), 1);
		}
	}
}
