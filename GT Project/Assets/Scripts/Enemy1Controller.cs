using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour {

	Rigidbody2D rb2d;
	public GameObject player;

	bool waiting = false;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (waiting == false) {
			StartCoroutine(waitToJump ());
		}
	}

	IEnumerator waitToJump() {
		waiting = true;
		yield return new WaitForSeconds (2.5f);
		waiting = false;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		print ("Collided");
		if (coll.gameObject.tag == "Player") {
			Destroy (player);
		}
	}
}
