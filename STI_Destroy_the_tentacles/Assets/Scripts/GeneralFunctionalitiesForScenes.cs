using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralFunctionalitiesForScenes : MonoBehaviour {

	public string sceneName;
	public GameObject menuPanel;
	public GameObject tutorialPanel;

	public void Change(){
		Time.timeScale = 1;
		SceneManager.LoadScene (sceneName);
	}

	public void Exit(){
		Application.Quit ();
	}

	public void ChangeBetweenPanels(){
		if (menuPanel.activeInHierarchy) {
			menuPanel.SetActive (false);
			tutorialPanel.SetActive (true);
		}
	}
}
