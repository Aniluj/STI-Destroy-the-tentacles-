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

	void Awake(){
		movementAnimation = GetComponent<Animator> ();
		spriteRenderOfTheTentacle = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		tentacleSpawnController = GameObject.FindGameObjectWithTag ("Vortex").GetComponent<TentacleSpawnController>();
	}

	void Update () {
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
			spriteRenderOfTheTentacle.color = Color.white;
			transform.parent.gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
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
			spriteRenderOfTheTentacle.color = Color.white;
			transform.parent.gameObject.SetActive (false);
		}
		if (coll.gameObject.tag == "Bullet") {
			timesHitByBullets += 1;

		}
	}
}
