using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (gameObject.tag == "BounceUp") {  // Checks to see what type of power up the player triggered.
			player.GetComponent<PlayerController>().jumpForceY += 100;
			player.GetComponent<PlayerController> ().jumpForceX += 100;
			print ("Working");
		} else if (gameObject.tag == "FrictionUp") {
			print ("More stuff here please");
		}

		Destroy (gameObject);
	}
}
