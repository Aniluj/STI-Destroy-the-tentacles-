using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleProperties : MonoBehaviour {

	public int numberOfSpawnWhereIsTheTentacle;
	public TentacleSpawnController tentacleSpawnController;
	public bool activated = true;

	void Start () {
		tentacleSpawnController = GameObject.FindGameObjectWithTag ("Vortex").GetComponent<TentacleSpawnController>();
	}

	void Update () {
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Shield" || coll.gameObject.tag == "Bullet" || coll.gameObject.name == "Spaceship") {
			tentacleSpawnController.areEasySpawnPointsActive[numberOfSpawnWhereIsTheTentacle] = true;
			Debug.Log (numberOfSpawnWhereIsTheTentacle);
			transform.parent.gameObject.SetActive (false);
		}
	}
}
