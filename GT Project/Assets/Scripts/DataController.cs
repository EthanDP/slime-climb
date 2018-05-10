using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt ("levelNum", PlayerPrefs.GetInt("levelNum"));

		if (PlayerPrefs.GetInt ("levelNum") <= 1) {
			PlayerPrefs.SetInt ("levelNum", 2);
		}

		print (PlayerPrefs.GetInt("levelNum"));
	}

	void Update () {
		
	}

	public void LevelComplete(int levelNumber) {
		if (PlayerPrefs.GetInt("levelNum") < (levelNumber + 2)) {
			PlayerPrefs.SetInt ("levelNum", levelNumber + 2);
			print ("Set level to: " + (levelNumber + 2));
		}

		StartCoroutine (loadNext(levelNumber));
	}

	IEnumerator loadNext(int levelNumber) {
		yield return new WaitForSeconds (8f);
		SceneManager.LoadScene (levelNumber + 2);
	}
}
