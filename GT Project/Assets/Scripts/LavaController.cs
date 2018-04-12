using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	GameObject player;
	GameObject cam;
	GameObject deathHandler;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		deathHandler = GameObject.FindGameObjectWithTag ("DeathEvent");
	}

	void Update () {
		transform.Translate (0, .3f * Time.deltaTime, 0);	
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Player") {
			deathHandler.GetComponent<DeathHandler> ().PlayerDeath ();
		}
	}
}
