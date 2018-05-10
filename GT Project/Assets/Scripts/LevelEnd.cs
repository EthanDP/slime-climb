using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	public GameObject dataCont;
	public GameObject victoryText;

	public int levelNumber;

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Player") {
			dataCont.GetComponent<DataController> ().LevelComplete (levelNumber);
			victoryText.SetActive (true);
		}
	}
		
}
