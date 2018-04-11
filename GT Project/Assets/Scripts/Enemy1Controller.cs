using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour {

	Rigidbody2D rb2d;
	GameObject player;
	GameObject cam;

	public float waitInterval;
	public float jumpForceX;
	public float jumpForceY;

	short dir = -1;

	bool waiting = false;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
<<<<<<< HEAD
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
=======
>>>>>>> Shmaan's-Branch
	}

	void Update () {
		if (!waiting) {
			StartCoroutine(waitToJump ());
		}
	}

	IEnumerator waitToJump() {
		waiting = true;
		yield return new WaitForSeconds (waitInterval);
		Jump (jumpForceX, jumpForceY, dir);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		//I think we're generally supposed to use Debug.Log to print to the console
		Debug.Log ("Collided");
		if (coll.gameObject.tag == "Player") {
			cam.GetComponent<CameraScript> ().playerAlive = false;
			Destroy (player);

		} else if (Physics2D.Raycast (transform.position, Vector2.down).collider.gameObject.Equals (coll.gameObject)) {
			waiting = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		//changes move direction when hitting a wall
		dir *= -1;
		Debug.Log ("TRIGGERED");
	}

	void Jump (float x, float y, float dir) {
		rb2d.AddForce (new Vector2 (x * dir, y));
	}
}
