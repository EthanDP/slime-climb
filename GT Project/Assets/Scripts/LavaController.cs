using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	public GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		transform.Translate (0, .3f * Time.deltaTime, 0);	
	}

	void OnTriggerEnter2D (Collider2D coll) {
		Destroy (player);
	}
}
