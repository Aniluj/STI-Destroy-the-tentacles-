using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {

	public CameraShake cameraShakeScript;
	//public Animator spaceshipAnimator;
	//public Animator contentionShieldAnimator;
	public ShieldHealth contentionShieldHealthScript;
	public SpaceshipMovement spaceshipMovementeScript;
	public SpecialMovement spaceshipSpecialMovementScript;
	public Health spaceshipHealthScript;
	public bool playerLost;
	public GameObject inGameMenu;
	public InGamePause pauseScript;
	public GameObject leftFireOfSpaceship;
	public GameObject rightFireOfSpaceship;
	private bool activateTimer;
	private TentacleProperties propertiesOfTheTentacle;
	private float timer;
	private GameObject[] tentaclesOnScreen;

	void Start () {
		
	}
	

	void Update () {
		if (playerLost) {
			tentaclesOnScreen = GameObject.FindGameObjectsWithTag ("Tentacle's father");
			for (int i = 0; i < tentaclesOnScreen.Length; i++) {
				propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
				propertiesOfTheTentacle.tentacleAnimation.SetFloat ("runMultiplier", 0f);
			}
			playerLost = false;
			activateTimer = true;
			pauseScript.enabled = false;
			contentionShieldHealthScript.enabled = false;
			spaceshipHealthScript.enabled = false;
			spaceshipSpecialMovementScript.enabled = false;
			spaceshipMovementeScript.enabled = false;
			cameraShakeScript.cameraShakeActivated = true;
			rightFireOfSpaceship.SetActive (false);
			leftFireOfSpaceship.SetActive (false);
		}
		if (activateTimer) {
			timer += Time.deltaTime;
		}
		if (timer >= 2f) {
			inGameMenu.SetActive (true);
			Time.timeScale = 0;
		}
	}
}
