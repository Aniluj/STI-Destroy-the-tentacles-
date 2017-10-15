using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleProperties : MonoBehaviour {

	public int numberOfSpawnWhereIsTheTentacle;
	public TentacleSpawnController tentacleSpawnController;
	public bool activated = true;
	public Animator movementAnimation;
	public int quantityOfHitsToDie;
	private int timesHitByBullets;

	void Awake(){
		movementAnimation = GetComponent<Animator> ();
	}

	void Start () {
		tentacleSpawnController = GameObject.FindGameObjectWithTag ("Vortex").GetComponent<TentacleSpawnController>();
		timesHitByBullets = 0;
	}

	void Update () {
		if (timesHitByBullets == quantityOfHitsToDie) {
			timesHitByBullets = 0;
			tentacleSpawnController.areEasySpawnPointsActive[numberOfSpawnWhereIsTheTentacle] = true;
			transform.parent.gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Shield" || coll.gameObject.name == "Spaceship") {
			tentacleSpawnController.areEasySpawnPointsActive[numberOfSpawnWhereIsTheTentacle] = true;
			transform.parent.gameObject.SetActive (false);
		}
		if (coll.gameObject.tag == "Bullet") {
			timesHitByBullets += 1;
		}
	}
}
