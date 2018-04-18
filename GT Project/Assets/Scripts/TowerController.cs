using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	public float waitTime;
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

	void OnCollisionExit2D (Collision2D coll) {
		waiting = false;
	}

	IEnumerator waitToShoot () {
		waiting = true;
		yield return new WaitForSeconds (waitTime);
		createBullet ();
	}

	void createBullet () {
		print ("Shoot");
		Instantiate (bullet, transform.position + offset, transform.rotation);
		waiting = false;
	}
}
