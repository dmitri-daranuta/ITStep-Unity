using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string levelName) {
		SceneManager.LoadScene (levelName);
		print ("Level Loaded!");
	}

	public void QuitGame() {
		//Application.Quit ();  build only
		// System.Diagnostic
		//System.Diagnostics.Process.GetCurrentProcess().Kill(); // BRUTAL WAY
		UnityEditor.EditorApplication.isPlaying = false; // editor only
		print ("Exit");
	}

}
