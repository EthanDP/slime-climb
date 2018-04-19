using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

	public AudioClip noise;

	// Use this for initialization
	void Awake () {
		Destroy (gameObject, noise.length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
