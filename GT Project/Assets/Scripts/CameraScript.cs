using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float speed;
	Transform playerPos;

	void Update () {
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform;

		transform.position = Vector3.Lerp (transform.position, new Vector3 (playerPos.position.x, 
			playerPos.position.y, -10), speed);
	}
}
