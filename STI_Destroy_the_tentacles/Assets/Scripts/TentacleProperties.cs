using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleProperties : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Shield" || coll.gameObject.tag == "Bullet" || coll.gameObject.name == "Spaceship") {
			transform.parent.gameObject.SetActive (false);
		}
	}
}
