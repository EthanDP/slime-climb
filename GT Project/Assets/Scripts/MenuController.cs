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

	public void LevelChoice () {
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene().buildIndex + levelNumber);
	}
}
