using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	//No reason to have the player object be public, he is found using the script
	GameObject player;

	public PhysicsMaterial2D bounceMaterial;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (gameObject.tag == "BounceUp" && coll.tag == "Player") {  // Checks to see what type of power up the player triggered.
			player.GetComponent<PlayerController>().jumpForceY += 100;
			player.GetComponent<PlayerController> ().jumpForceX += 100;
			player.GetComponent<BoxCollider2D> ().sharedMaterial = bounceMaterial;
		} else if (gameObject.tag == "FrictionUp") {
			print ("More stuff here please");
		}

		Destroy (gameObject);
	}
}
