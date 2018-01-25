using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShieldHealth : MonoBehaviour {

	//public Slider shieldHealthBar;
	public int damageReceived;
	public int initialLife;
	public GameObject contentionShieldHitted;
	public Animator shieldOfTheHealthBarAnimator;
	public Animator contentionShieldHealthBarAnimator;
	public int health;
	private bool contentionShieldIsHitted;
	private float timerForWhenIsHitted;
	private int upgradeHealthIsActive;
	private string upgradeOfShieldHealthKey = "upgradeOfShieldHealth";
	private SpriteRenderer spriteRendererOfTheShield;
	private Animator shieldAnimator;

	void Awake(){
		shieldAnimator = GetComponent<Animator> ();
		//spriteRendererOfTheShield = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		upgradeHealthIsActive = PlayerPrefs.GetInt (upgradeOfShieldHealthKey);
		Debug.Log (upgradeHealthIsActive);
		if (upgradeHealthIsActive == 1) {
			//initialLife = 175;
			health = 5;
		} else {
			//initialLife = 100;
			initialLife = 5;
		}
		//shieldHealthBar.maxValue = initialLife;
		//shieldHealthBar.value = initialLife;
		health = initialLife;
	}
	
	void Update(){
		contentionShieldHealthBarAnimator.SetInteger ("HealthStatus", health);
		Debug.Log (health);
		if (health >= 5 && upgradeHealthIsActive != 1) {
			health = 5;
		}
		if (health <= 0) {
			SceneManager.LoadScene ("Market");
		}
		if (contentionShieldIsHitted) {
			contentionShieldHitted.SetActive (true);
			timerForWhenIsHitted += Time.deltaTime;
		}
		if (timerForWhenIsHitted >= 0.3f) {
			contentionShieldHitted.SetActive (false);
			timerForWhenIsHitted = 0f;
			contentionShieldIsHitted = false;
		}
		if (health > 0 && health <= initialLife/5) {
			//spriteRendererOfTheShield.color = Color.red;
			shieldAnimator.SetBool("FullHealth", false);
			shieldAnimator.SetBool ("HalfHealth", false);
			shieldAnimator.SetBool ("LowHealth", true);
			shieldOfTheHealthBarAnimator.SetInteger ("HealthStatus", 3);
		}
		if (health > initialLife/5 && health <= initialLife/1.5f) {
			//spriteRendererOfTheShield.color = Color.red;
			shieldAnimator.SetBool("FullHealth", false);
			shieldAnimator.SetBool ("LowHealth", false);
			shieldAnimator.SetBool ("HalfHealth", true);
			shieldOfTheHealthBarAnimator.SetInteger ("HealthStatus", 2);
		}
		if(health <= initialLife && health > initialLife/1.5f){
			//spriteRendererOfTheShield.color = Color.white;
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
