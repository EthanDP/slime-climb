using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float gravityScale;
	public float jumpForceX;
	public float jumpForceY;
	public int maxJumpCount;
	[SerializeField]
	int jumpCount;

	Vector2 start;
	Vector2 end;
	Vector2 jumpForce;
	Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		jumpCount = maxJumpCount;
	}

	void Update () {
		jumpForce = new Vector2 (jumpForceX, jumpForceY);

		if (Input.GetMouseButtonDown (0)) {
			start = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp (0) && jumpCount > 0) {
			end = Input.mousePosition;
			jumpCount--;
			Vector2 jumpDirection = (end - start);
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce (Vector2.Scale(jumpDirection.normalized, jumpForce));
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		// Disable gravity when in contact with a wall, may want to add tags later so it doesn't stick to enemies
		jumpCount = maxJumpCount;
		rb2d.gravityScale = 0.05f;

	}

	void OnCollisionStay2D (Collision2D coll) {
		// Does this segment check if your input didn't change the players position and make sure jumpCount stays the same?
		jumpCount = maxJumpCount;
	}

	void OnCollisionExit2D (Collision2D coll) {
		// Resets gravity value when no longer touching an object
		jumpCount--;
		rb2d.gravityScale = gravityScale;
	}
}