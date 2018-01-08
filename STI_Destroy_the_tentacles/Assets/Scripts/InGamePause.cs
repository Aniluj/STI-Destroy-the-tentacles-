using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePause : MonoBehaviour {

	private bool paused = false;
	public GameObject InGameMenu;
	public AudioSource InGameMusic;

	void Start () {
		
	}
	

	void Update () {
		
		if (Input.GetButtonDown ("Pause") && !paused) {
			InGameMenu.SetActive (true);
			InGameMusic.Pause ();
			paused = true;
			Time.timeScale = 0;
		} else if (Input.GetButtonDown ("Pause") && paused) {
			InGameMenu.SetActive (false);
			InGameMusic.Play ();
			paused = false;
			Time.timeScale = 1;
		}

		if (!InGameMenu.activeInHierarchy) {
			Time.timeScale = 1;
		}

	}
}
