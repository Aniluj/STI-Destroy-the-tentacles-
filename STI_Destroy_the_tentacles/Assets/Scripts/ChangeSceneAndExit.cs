using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAndExit : MonoBehaviour {

	public string sceneName;

	public void Change(){
		SceneManager.LoadScene (sceneName);
	}

	public void Exit(){
		Application.Quit ();
	}
}
