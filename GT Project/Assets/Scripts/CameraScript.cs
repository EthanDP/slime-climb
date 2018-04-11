using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float speed;
	Transform playerPos;
	public bool playerAlive = true;

	void LateUpdate () {
		if (playerAlive == true) {
			playerPos = GameObject.FindGameObjectWithTag("Player").transform;
			transform.position = Vector3.Lerp (transform.position, new Vector3 (0, playerPos.position.y, -10), speed);
		}
	}
}
