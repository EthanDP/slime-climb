using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAroundScript : MonoBehaviour {

    public float halfWidth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate () {
		// NOTE: this works only if the cam center is at 0,0
		Vector3 pos = transform.position;

		//*** apply your movement here ***
		// change pos as you want

		// this is the half size of the screen (so it goes from -9.0f to 9.0f)
		float HalfScreenSize = halfWidth;

		// wrap check
		pos.x = Mathf.Repeat(pos.x+HalfScreenSize,HalfScreenSize*2)-HalfScreenSize;

		transform.position = pos;
    }
		
}
