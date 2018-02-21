using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePause : MonoBehaviour {

	private bool paused = false;
	public AudioSource pauseSFX;
	public AudioSource ambientSFX;
	public GameObject InGameMenu;
	public AudioSource InGameMusic;
	public SpaceshipMovement spaceshipMovementScriptOfTheSpaceship;
	public LoadingScreenFadeInOut loadingScreenScript;
	public Animator spaceshipAnimator;


	void Start () {
		
	}
	

	void Update () {
		
		if (Input.GetButtonDown ("Pause") && !paused && !loadingScreenScript.activateFadeIn) {
			InGameMenu.SetActive (true);
			InGameMusic.Pause ();
			pauseSFX.Play ();
			ambientSFX.Play ();
			paused = true;
			spaceshipAnimator.enabled = false;
			spaceshipMovementScriptOfTheSpaceship.enabled = false;
			Time.timeScale = 0;
		} else if (Input.GetButtonDown ("Pause") && paused && !loadingScreenScript.activateFadeIn) {
			InGameMenu.SetActive (false);
			InGameMusic.Play ();
			pauseSFX.Stop ();
			ambientSFX.Pause ();
			paused = false;
			spaceshipAnimator.enabled = true;
			spaceshipMovementScriptOfTheSpaceship.enabled = true;
			Time.timeScale = 1;
		}

		if (!InGameMenu.activeInHierarchy) {
			Time.timeScale = 1;
		}

	}
}
