using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleProperties : MonoBehaviour {

	public int numberOfSpawnWhereIsTheTentacle;
	public TentacleSpawnController tentacleSpawnController;
	public bool activated = true;
	public Animator movementAnimation;
	public SpriteRenderer spriteRenderOfTheTentacle;
	public int quantityOfHitsToDie;
	public string typeOfSpawnWhereIsTheTentacle;
	private int timesHitByBullets = 0;
	private Color colorWhileIsHitted;
	private Color baseColor;
	private float durationOfTheChangeOfColorWhenIsHitted;
	private float timer;
	private bool hitted = false;

	void Awake(){
		movementAnimation = GetComponent<Animator> ();
		spriteRenderOfTheTentacle = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		durationOfTheChangeOfColorWhenIsHitted = 0.25f;
		tentacleSpawnController = GameObject.FindGameObjectWithTag ("Vortex").GetComponent<TentacleSpawnController>();
		//colorWhileIsHitted = spriteRenderOfTheTentacle.color;
		//colorWhileIsHitted.a = 0f;
		baseColor = spriteRenderOfTheTentacle.color;
	}

	void Update () {
		if (hitted ) {
			timer += Time.deltaTime;
			//spriteRenderOfTheTentacle.color = colorWhileIsHitted;
			spriteRenderOfTheTentacle.color = Color.grey;
		}
		if (timer > durationOfTheChangeOfColorWhenIsHitted) {
			timer = 0;
			spriteRenderOfTheTentacle.color = baseColor;
			hitted = false;
		}
		if (timesHitByBullets >= quantityOfHitsToDie) {
			timesHitByBullets = 0;
			if (typeOfSpawnWhereIsTheTentacle == "easy") {
				tentacleSpawnController.areEasySpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			if (typeOfSpawnWhereIsTheTentacle == "medium") {
				tentacleSpawnController.areMediumSpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			if (typeOfSpawnWhereIsTheTentacle == "hard") {
				tentacleSpawnController.areHardSpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			transform.parent.gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		timer += Time.deltaTime;
		if (coll.gameObject.tag == "Shield" || coll.gameObject.name == "Spaceship") {
			if (typeOfSpawnWhereIsTheTentacle == "easy") {
				tentacleSpawnController.areEasySpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			if (typeOfSpawnWhereIsTheTentacle == "medium") {
				tentacleSpawnController.areMediumSpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			if (typeOfSpawnWhereIsTheTentacle == "hard") {
				tentacleSpawnController.areHardSpawnPointsActive [numberOfSpawnWhereIsTheTentacle] = true;
			}
			timesHitByBullets = 0;
			transform.parent.gameObject.SetActive (false);
		}
		if (coll.gameObject.tag == "Bullet") {
			timesHitByBullets += 1;
			hitted = true;
		}
	}
}
