using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {

	void Start () {
		DontDestroyOnLoad (gameObject);
		PlayerPrefs.SetInt ("levelNum", PlayerPrefs.GetInt("levelNum"));

		if (PlayerPrefs.GetInt ("levelNum") <= 1) {
			PlayerPrefs.SetInt ("levelNum", 2);
		}

		print (PlayerPrefs.GetInt("levelNum"));
	}

	void Update () {
		
	}
}
