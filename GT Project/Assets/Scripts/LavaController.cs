using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	public GameObject player;
	public GameObject cam;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update () {
		transform.Translate (0, .3f * Time.deltaTime, 0);	
	}

	void OnTriggerEnter2D (Collider2D coll) {
		cam.GetComponent<CameraScript> ().playerAlive = false;
		Destroy (player);

	}
}
