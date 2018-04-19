using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

	public GameObject gameOver;
	public GameObject particle;
	public GameObject deathNoise;

	GameObject cam;
	GameObject player;

	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public void PlayerDeath () {
		cam.GetComponent<CameraScript> ().playerAlive = false;
		gameOver.SetActive (true);
		Vector2 playerPosition = player.transform.position;
		Destroy (player);
		Instantiate (particle, playerPosition, transform.rotation);
		Instantiate (deathNoise);

	}
}
