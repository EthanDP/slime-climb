using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

	public GameObject gameOver;
	GameObject cam;
	GameObject player;

	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public void PlayerDeath () {
		cam.GetComponent<CameraScript> ().playerAlive = false;
		gameOver.SetActive (true);
		Destroy (player);
	}
}
