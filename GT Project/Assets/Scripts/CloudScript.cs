using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

	public GameObject player;

	void Start () {
		
	}

	void Update () {
		if (player.transform.position.y - .055f >= transform.position.y) {
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
		} else {
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		}
	}
}
