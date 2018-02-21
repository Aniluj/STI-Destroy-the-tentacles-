using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleProperties : MonoBehaviour {

	public int numberOfSpawnWhereIsTheTentacle;
	public TentacleSpawnController tentacleSpawnController;
	public bool activated = true;
	public Animator tentacleAnimation;
	public Animator miniVortexOpenedAnimation;
	public SpriteRenderer spriteRenderOfTheTentacle;
	public int quantityOfHitsToDie;
	public string typeOfSpawnWhereIsTheTentacle;
	public bool slowdownActivated = false;
	private int timesHitByBullets = 0;
	private int isTheSpriteRendererFliped;
	private Color obscureBlue = new Color(0.25f,0.25f,1f,1f);
	private Color colorWhileIsHitted;
	private Color baseColor;
	private float durationOfTheChangeOfColorWhenIsHitted;
	private float timer;
	private bool hitted = false;
	private bool tentacleIsDead = false;
	private BoxCollider2D tentacleBoxCollider;

	void Awake(){
		tentacleBoxCollider = GetComponent<BoxCollider2D> ();
		tentacleAnimation = GetComponent<Animator> ();
		miniVortexOpenedAnimation = transform.parent.GetComponent<Animator> ();
		spriteRenderOfTheTentacle = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		tentacleAnimation.SetBool ("isDying", false);
		durationOfTheChangeOfColorWhenIsHitted = 0.25f;
		isTheSpriteRendererFliped = Random.Range (0, 2);
		if (isTheSpriteRendererFliped == 1) {
			spriteRenderOfTheTentacle.flipX = true;
		}
		tentacleSpawnController = GameObject.FindGameObjectWithTag ("Vortex").GetComponent<TentacleSpawnController>();
		//colorWhileIsHitted = spriteRenderOfTheTentacle.color;
		//colorWhileIsHitted.a = 0f;
		baseColor = spriteRenderOfTheTentacle.color;
	}

	void Update () {
		if (miniVortexOpenedAnimation.GetCurrentAnimatorStateInfo (0).IsName("openingMiniVortex")) {
			miniVortexOpenedAnimation.SetBool ("miniVortexOpened", true);
		}
		if (hitted) {
			timer += Time.deltaTime;
			//spriteRenderOfTheTentacle.color = colorWhileIsHitted;
			spriteRenderOfTheTentacle.color = Color.grey;
		}
		if (!slowdownActivated && timer > durationOfTheChangeOfColorWhenIsHitted) {
			timer = 0;
			spriteRenderOfTheTentacle.color = baseColor;
			hitted = false;
		} else if (slowdownActivated && timer > durationOfTheChangeOfColorWhenIsHitted) {
			timer = 0;
			tentacleAnimation.SetBool ("Frozen", true);
			spriteRenderOfTheTentacle.color = baseColor;
			hitted = false;
		}
		if (timesHitByBullets >= quantityOfHitsToDie) {
			tentacleIsDead = true;
			miniVortexOpenedAnimation.SetBool ("miniVortexOpened", false);
		}
		if (tentacleIsDead) {
			tentacleAnimation.SetFloat ("runMultiplier", 0f);
			tentacleAnimation.SetBool ("isDying", true);
			tentacleBoxCollider.enabled = false;
		} else {
			tentacleBoxCollider.enabled = true;
		}
		if ((tentacleAnimation.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1f) && (tentacleAnimation.GetCurrentAnimatorStateInfo (0).IsName ("TentacleDeathAnimation") || tentacleAnimation.GetCurrentAnimatorStateInfo (0).IsName ("FrozenTentacleDeath"))) {
			timesHitByBullets = 0;
			tentacleIsDead = false;
			if (typeOfSpawnWhereIsTheTentacle == "easy") {
				tentacleSpawnController.areEasySpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			if (typeOfSpawnWhereIsTheTentacle == "medium") {
				tentacleSpawnController.areMediumSpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			if (typeOfSpawnWhereIsTheTentacle == "hard") {
				tentacleSpawnController.areHardSpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			slowdownActivated = false;
			transform.parent.gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		timer += Time.deltaTime;
		if (coll.gameObject.tag == "Shield" || coll.gameObject.name == "Spaceship") {
			tentacleIsDead = true;
		}
		if (coll.gameObject.tag == "Bullet") {
			timesHitByBullets += 1;
			hitted = true;
		}
	}
}
