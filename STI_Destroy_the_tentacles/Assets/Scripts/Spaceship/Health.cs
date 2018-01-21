using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public Slider healthBar;
	public Slider overheatSlider;
	public int damageReceived;
	public int damageWhenSpecialMovementIsActive;
	public int damage;
	public float initialHealth;
	public GameObject inGameMenu;
	public CameraShake cameraShakeScript;
	private int upgradeOfHealthIsActive;
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private SpriteRenderer spriteRendererOfTheSpaceship;
	private Animator spaceshipAnimator;
	private float timer;
	private SpaceshipMovement spaceshipMovementScript;

	void Awake(){
		spaceshipAnimator = GetComponent<Animator> ();
		spriteRendererOfTheSpaceship = GetComponent<SpriteRenderer> ();
		spaceshipMovementScript = GetComponent<SpaceshipMovement> ();
	}

	void Start () {
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey);
		if (upgradeOfHealthIsActive == 1) {
			initialHealth = 175f;
		} else {
			initialHealth = 100f;
		}
		damageWhenSpecialMovementIsActive = 0;
		healthBar.maxValue = initialHealth;
		healthBar.value = initialHealth;
	}
	
	void Update(){
		if (healthBar.value <= 0) {
			spaceshipAnimator.SetBool ("IsDead", true);
			overheatSlider.gameObject.SetActive (false);
			spaceshipMovementScript.enabled = false;
			timer += Time.deltaTime;
			if (timer >= 0 && timer < 0.5) {
				cameraShakeScript.cameraShakeActivated = true;
			}
			if (timer >= 2f) {
				inGameMenu.SetActive (true);
				Time.timeScale = 0;
			}
		}
		if (healthBar.value > 0 && healthBar.value <= initialHealth / 4) {
			spaceshipAnimator.SetFloat ("HealthStatus", 1f);
		}
		if (healthBar.value > initialHealth/4 && healthBar.value <= initialHealth/2) {
			spaceshipAnimator.SetFloat ("HealthStatus", 0.5f);
		}
		if(healthBar.value <= initialHealth && healthBar.value > initialHealth/2){
			spaceshipAnimator.SetFloat ("HealthStatus", 0f);
		}
	}
	void OnCollisionEnter2D (Collision2D coll)	{
		if (coll.gameObject.tag == "Tentacle") {
			healthBar.value -= damage;
		}
	}
}
