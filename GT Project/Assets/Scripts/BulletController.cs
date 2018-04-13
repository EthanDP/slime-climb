using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	Rigidbody2D rb2d;

	bool moveLeft;
	bool testedDirection = false;

	void Start () {

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
			
		} else if (moveLeft = false) {
			
		}
	}
}
