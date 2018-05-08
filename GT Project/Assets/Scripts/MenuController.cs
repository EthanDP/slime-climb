using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuController : MonoBehaviour {

	public int levelNumber;

	public void LevelSelect () {
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void OptionsMenu () {
		
	}

	public void Quit () {
		Application.Quit ();

	}

	public void resetLevel () {
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1.0f;
	}

	public void MenuChoice (int sceneNumber) {
		EditorSceneManager.LoadScene (sceneNumber);
	}

	public void LevelChoice () {
		if (PlayerPrefs.GetInt ("levelNum") >= EditorSceneManager.GetActiveScene ().buildIndex + levelNumber) {
			EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene ().buildIndex + levelNumber);
		} else {
			print ("Not unlocked");
		}
	}
}
