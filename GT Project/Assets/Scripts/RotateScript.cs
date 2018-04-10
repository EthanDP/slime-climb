using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

	bool hasRotated = false;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll) {

		RaycastHit2D hit;
		//Spits a raycast left, right and down, rotates to be perpendicular the ray hits the object colliding with
		hit = Physics2D.Raycast (transform.position, Vector2.down);
		if (hit.collider.gameObject.Equals (coll.gameObject) && !hasRotated) {
			transform.rotation = Quaternion.Euler (Vector3.zero);
			hasRotated = true;
		}
		hit = Physics2D.Raycast (transform.position, Vector2.left);
		if (hit.collider.gameObject.Equals (coll.gameObject) && !hasRotated) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, -90));
			hasRotated = true;
		}
		hit = Physics2D.Raycast (transform.position, Vector2.right);
		if (hit.collider.gameObject.Equals (coll.gameObject) && !hasRotated) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 90));
		}

	}

	void OnCollisionExit2D (Collision2D coll) {
		hasRotated = false;
	}
}
