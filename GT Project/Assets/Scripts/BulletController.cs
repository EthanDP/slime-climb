using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float bulletSpeed;

	GameObject deathHandler;

	bool moveLeft = true;
	bool testedDirection = false;

	void Awake () {
		deathHandler = GameObject.FindGameObjectWithTag ("DeathEvent");
	}

	void Update () {
		if (!testedDirection) {
			RaycastHit2D hit;
			hit = Physics2D.Raycast (transform.position, Vector2.right, 10);
			if (hit.collider.gameObject.tag == "BTower") {
				moveLeft = true;
				print ("Hit tower");
			} else {
				moveLeft = false;
				print("No collision");
			}

			testedDirection = true;
		} else {
			Movement ();
		}
	}

	void Movement () { 
		if (moveLeft = true) {
			transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
		} else if (moveLeft = false) {
			transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Player") {
			deathHandler.GetComponent<DeathHandler> ().PlayerDeath ();
		} else {
			Destroy (gameObject);
		}
	}
}
