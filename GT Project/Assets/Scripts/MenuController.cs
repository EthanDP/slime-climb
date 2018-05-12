using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public int levelNumber;

	public GameObject menuElements;
	public GameObject pauseElements;

	public void LevelSelect () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void Quit () {
		Application.Quit ();

	}

	public void resetLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1.0f;
	}

	public void MenuChoice (int sceneNumber) {
		SceneManager.LoadScene (sceneNumber);
		Time.timeScale = 1.0f;
	}

	public void LevelChoice () {
		if (PlayerPrefs.GetInt ("levelNum") >= SceneManager.GetActiveScene ().buildIndex + levelNumber) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + levelNumber);
		} else {
			print ("Not unlocked");
		}
	}

	public void OptionsMenu (bool toOptions) {
		if (toOptions) {
			menuElements.SetActive (false);
			pauseElements.SetActive (true);
		} else {
			menuElements.SetActive (true);
			pauseElements.SetActive (false);
		}
	}

	public void unlockLevels () {
		PlayerPrefs.SetInt ("levelNum", 20);
	}

}
