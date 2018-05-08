using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour {

	Rigidbody2D rb2d;
	GameObject deathHandler;

	public float waitInterval;
	public float jumpForceX;
	public float jumpForceY;

	float startTime;

	short dir = 1;

	bool waiting = false;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		deathHandler = GameObject.FindGameObjectWithTag ("DeathEvent");
	}

	void Update () {
		if (Time.time - startTime > 5f && waiting) {
			waiting = false;
		}

		if (!waiting) {
			StartCoroutine(waitToJump ());
		}
	}

	IEnumerator waitToJump() {
		waiting = true;
		yield return new WaitForSeconds (waitInterval);
		Jump (jumpForceX, jumpForceY, dir);

		startTime = Time.time;

		if (Random.Range (-1, 1) > 0) {
			dir *= 1;
		} else {
			dir *= -1;
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		//I think we're generally supposed to use Debug.Log to print to the console
		Debug.Log ("Collided");
		if (coll.gameObject.tag == "Player") {
			deathHandler.GetComponent<DeathHandler> ().PlayerDeath ();
		} else if (Physics2D.Raycast (transform.position + new Vector3 (.225f, 0, 0), Vector2.down).collider.gameObject.Equals (coll.gameObject)) {
			waiting = false;
		} else if (Physics2D.Raycast (transform.position + new Vector3 (-.225f, 0, 0), Vector2.down).collider.gameObject.Equals (coll.gameObject)) {
			waiting = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		//changes move direction when hitting a wall
		dir *= -1;
	}

	void Jump (float x, float y, float dir) {
		rb2d.AddForce (new Vector2 (x * dir, y));
	}
}
