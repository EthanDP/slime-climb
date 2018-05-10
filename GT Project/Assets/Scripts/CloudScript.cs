using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

	public GameObject player;
	public bool isSpike = false;

	GameObject deathHandler;

	void Start () {
		deathHandler = GameObject.FindGameObjectWithTag ("DeathEvent");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (player != null && player.transform.position.y - .055f >= transform.position.y) {
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
		} else {
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (isSpike && coll.gameObject.tag == "Player") {
			deathHandler.GetComponent<DeathHandler> ().PlayerDeath ();
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
