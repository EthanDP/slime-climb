using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float speed;
	public bool playerAlive = true;

	Transform playerPos;
	float startY;

	void LateUpdate () {
		if (playerAlive == true) {
			playerPos = GameObject.FindGameObjectWithTag("Player").transform;
			transform.position = Vector3.Lerp (transform.position, new Vector3 (0, playerPos.position.y, -10), speed);
		} else if (playerAlive == false && transform.position.y >= startY) {
			Vector3.Lerp (transform.position, new Vector3 (0, startY, -10), 1);
		}
	}

	void Start () {
		startY = transform.position.y;

		float targetaspect = 10.0f / 16.0f;

		float windowaspect = (float)Screen.width / (float)Screen.height;

		float scaleheight = windowaspect / targetaspect;

		Camera camera = GetComponent<Camera>();

		if (scaleheight < 1.0f) {  
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			camera.rect = rect;
		} else {
			float scalewidth = 1.0f / scaleheight;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}
	}
}
