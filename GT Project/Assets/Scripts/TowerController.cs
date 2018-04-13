using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	public Transform bullet;
	public Vector3 offset = new Vector3(-.3f, .3f, 0);

	bool waiting = false;


	void Update () {
		if (waiting == false) {
			StartCoroutine (waitToShoot ());
		}
	}

	void OnCollisionStay2D (Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			waiting = true;  // Doesn't shoot if the player is touching the tower.
		}
	}

	IEnumerator waitToShoot () {
		waiting = true;
		yield return new WaitForSeconds (3f);
		createBullet ();
	}

	void createBullet () {
		print ("Shoot");
		Instantiate (bullet, transform.position + offset, transform.rotation);
	}
}
