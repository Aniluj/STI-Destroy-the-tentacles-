using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	//public Slider healthBar;
	public Slider overheatSlider;
	public Animator spaceshipOfTheHealthBarAnimator;
	public Animator spaceshipHealthBarAnimator;
	public int damageReceived;
	public int damageWhenSpecialMovementIsActive;
	public int damage;
	public int initialHealth;
	public int health;
	public GameObject inGameMenu;
	public CameraShake cameraShakeScript;
	public GameObject rightFire;
	public GameObject leftFire;
	public GameObject hittedSpaceship;
	private bool spaceshipIsHitted;
	private int upgradeOfHealthIsActive;
	private string upgradeOfHealthKey = "upgradeOfHealth";
	private SpriteRenderer spriteRendererOfTheSpaceship;
	private Animator spaceshipAnimator;
	private float timer;
	private float timerForWhenIsHitted;
	private SpaceshipMovement spaceshipMovementScript;

	void Awake(){
		spaceshipAnimator = GetComponent<Animator> ();
		spriteRendererOfTheSpaceship = GetComponent<SpriteRenderer> ();
		spaceshipMovementScript = GetComponent<SpaceshipMovement> ();
	}

	void Start () {
		upgradeOfHealthIsActive = PlayerPrefs.GetInt (upgradeOfHealthKey);
		if (upgradeOfHealthIsActive == 1) {
			initialHealth = 7;
		} else {
			initialHealth = 5;
		}
		damageWhenSpecialMovementIsActive = 0;
		health = initialHealth;
		spaceshipHealthBarAnimator.SetInteger ("UpgradeStatus", upgradeOfHealthIsActive);
	}
	
	void Update(){
		spaceshipHealthBarAnimator.SetInteger ("HealthStatus", health);
		if (health >= initialHealth) {
			health = initialHealth;
		}
		if (spaceshipIsHitted) {
			spriteRendererOfTheSpaceship.color = Color.grey;
			timerForWhenIsHitted += Time.deltaTime;
		}
		if (timerForWhenIsHitted >= 0.2f) {
			spaceshipIsHitted = false;
			spriteRendererOfTheSpaceship.color = Color.white;
			timerForWhenIsHitted = 0;
		}
		if (health <= 5) {
			spaceshipHealthBarAnimator.SetLayerWeight (0, 1);
			spaceshipHealthBarAnimator.SetLayerWeight (1, 0);
		} else if (health > 5) {
			spaceshipHealthBarAnimator.SetLayerWeight (0, 0);
			spaceshipHealthBarAnimator.SetLayerWeight (1, 1);
		}
		if (health <= 0) {
			spaceshipAnimator.SetBool ("IsDead", true);
			rightFire.SetActive (false);
			leftFire.SetActive (false);
			overheatSlider.gameObject.SetActive (false);
			spaceshipMovementScript.enabled = false;
			timer += Time.deltaTime;
			if (timer >= 0f && timer < 0.2f) {
				cameraShakeScript.cameraShakeActivated = true;
			}
			if (timer >= 2f) {
				inGameMenu.SetActive (true);
				Time.timeScale = 0;
			}
		}
		if (health > 0 && health <= initialHealth / 5f) {
			spaceshipAnimator.SetFloat ("HealthStatus", 1f);
			spaceshipOfTheHealthBarAnimator.SetInteger ("HealthStatus", 3);
		}
		if (health > initialHealth/5f && health <= initialHealth/1.5f) {
			spaceshipAnimator.SetFloat ("HealthStatus", 0.5f);
			spaceshipOfTheHealthBarAnimator.SetInteger ("HealthStatus", 2);
		}
		if(health <= initialHealth && health > initialHealth/1.5f){
			spaceshipAnimator.SetFloat ("HealthStatus", 0f);
			spaceshipOfTheHealthBarAnimator.SetInteger ("HealthStatus", 1);
		}
	}

	void OnCollisionEnter2D (Collision2D coll)	{
		if (coll.gameObject.tag == "Tentacle") {
			//healthBar.value -= damage;
			health -= damage;
			spaceshipIsHitted = true;
		}
	}
}
