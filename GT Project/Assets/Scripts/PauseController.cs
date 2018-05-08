using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

	public GameObject buttons;
	public GameObject pauseButton;

	public void onClick () {
		buttons.SetActive (true);
		pauseButton.SetActive (false);
		Time.timeScale = 0f;
	} 

	public void onResume () {
		buttons.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1.0f;
	}
}
