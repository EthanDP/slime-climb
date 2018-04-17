using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void LevelSelect () {
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void OptionsMenu () {
		
	}

	public void Quit () {
		Application.Quit ();
	}
}
