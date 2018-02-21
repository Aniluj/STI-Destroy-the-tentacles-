using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathController : MonoBehaviour {

	public CameraShake cameraShakeScript;
	public ShieldHealth contentionShieldHealthScript;
	public SpaceshipMovement spaceshipMovementeScript;
	public SpecialMovement spaceshipSpecialMovementScript;
	public Health spaceshipHealthScript;
	public bool playerLost;
	public GameObject inGameMenu;
	public GameObject youLostImage;
	public InGamePause pauseScript;
	public GameObject leftFireOfSpaceship;
	public GameObject rightFireOfSpaceship;
	public GameObject[] powerUpsAndController;
	public TextMeshProUGUI keyOfPowerUp;
	public SpriteRenderer spaceshipRenderer;
	public SpriteRenderer contentionShieldRenderer;
	public Shoot shootScript;
	private bool activateTimer;
	private TentacleProperties propertiesOfTheTentacle;
	private float timer;
	private GameObject[] tentaclesOnScreen;


	void Update () {
		if (playerLost) {
			tentaclesOnScreen = GameObject.FindGameObjectsWithTag ("Tentacle's father");
			spaceshipRenderer.color = Color.white;
			contentionShieldRenderer.color = Color.white;
			for (int i = 0; i < tentaclesOnScreen.Length; i++) {
				propertiesOfTheTentacle = tentaclesOnScreen [i].transform.GetChild (0).GetComponent<TentacleProperties> ();
				propertiesOfTheTentacle.tentacleAnimation.SetFloat ("runMultiplier", 0f);
			}
			for (int i = 0; i < powerUpsAndController.Length; i++) {
				powerUpsAndController [i].SetActive (false);
			}
			keyOfPowerUp.enabled = false;
			playerLost = false;
			activateTimer = true;
			pauseScript.enabled = false;
			shootScript.enabled = false;
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
			youLostImage.SetActive (true);
			Time.timeScale = 0;
		}
	}
}
