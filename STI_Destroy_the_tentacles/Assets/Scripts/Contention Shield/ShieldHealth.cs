using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShieldHealth : MonoBehaviour {

	//public Slider shieldHealthBar;
	public DeathController deathControllerScript;
	public int damageReceived;
	public int initialHealth;
	public Animator shieldOfTheHealthBarAnimator;
	public Animator contentionShieldHealthBarAnimator;
	public AudioSource ambientSFX;
	public AudioSource shieldExplosionSFX;
	public AudioSource inGameMusic;
	public int health;
	private bool contentionShieldIsHitted;
	private float timerForWhenIsHitted;
	private int upgradeHealthIsActive;
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";
	private SpriteRenderer spriteRendererOfTheShield;
	private Animator shieldAnimator;

	void Awake(){
		shieldAnimator = GetComponent<Animator> ();
		spriteRendererOfTheShield = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		upgradeHealthIsActive = PlayerPrefs.GetInt (upgradeOfShieldHealthKey);
		if (upgradeHealthIsActive == 1) {
			initialHealth = 7;
		} else {
			initialHealth = 5;
		}
		health = initialHealth;
		contentionShieldHealthBarAnimator.SetInteger ("UpgradeStatus", upgradeHealthIsActive);
	}
	
	void Update(){
		contentionShieldHealthBarAnimator.SetInteger ("HealthStatus", health);
		if (health > initialHealth) {
			health = initialHealth;
		} 
		if (health > 5) {
			contentionShieldHealthBarAnimator.SetLayerWeight (0, 0);
			contentionShieldHealthBarAnimator.SetLayerWeight (1, 1);
		} else if (health <= 5) {
			contentionShieldHealthBarAnimator.SetLayerWeight (1, 0);
			contentionShieldHealthBarAnimator.SetLayerWeight (0, 1);
		}
		if (health <= 0) {
			shieldAnimator.SetInteger ("HealthStatus", 0);
			deathControllerScript.playerLost = true;
			inGameMusic.Stop ();
			ambientSFX.Stop ();
			ambientSFX.Play ();
			shieldExplosionSFX.time = 0.5f;
			shieldExplosionSFX.Play ();
		}
		if (contentionShieldIsHitted) {
			spriteRendererOfTheShield.color = Color.grey;
			timerForWhenIsHitted += Time.deltaTime;
		}
		if (timerForWhenIsHitted >= 0.3f) {
			spriteRendererOfTheShield.color = Color.white;
			timerForWhenIsHitted = 0f;
			contentionShieldIsHitted = false;
		}
		if (health > 0 && health <= 1) {
			shieldAnimator.SetBool("FullHealth", false);
			shieldAnimator.SetBool ("HalfHealth", false);
			shieldAnimator.SetBool ("LowHealth", true);
			shieldOfTheHealthBarAnimator.SetInteger ("HealthStatus", 3);
		}
		if (health > 1 && health <= initialHealth/1.5f) {
			shieldAnimator.SetBool("FullHealth", false);
			shieldAnimator.SetBool ("LowHealth", false);
			shieldAnimator.SetBool ("HalfHealth", true);
			shieldOfTheHealthBarAnimator.SetInteger ("HealthStatus", 2);
		}
		if(health <= initialHealth && health > initialHealth/1.5f){
			shieldAnimator.SetBool ("LowHealth", false);
			shieldAnimator.SetBool ("HalfHealth", false);
			shieldAnimator.SetBool("FullHealth", true);
			shieldOfTheHealthBarAnimator.SetInteger ("HealthStatus", 1);

		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Tentacle") {
			contentionShieldIsHitted = true;
			health -= damageReceived;
		}
	}
}
