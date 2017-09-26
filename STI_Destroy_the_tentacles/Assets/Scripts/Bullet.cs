using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody2D bullet;
	public float velocity;

	void Awake (){
		bullet = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		
	}

	void Update () {
		//transform.Translate (Vector2.right * velocity * Time.deltaTime);
		bullet.AddRelativeForce (Vector2.right * velocity);
	}

	void FixedUpdate (){
		
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Tentacle" || coll.gameObject.name == "Contention shield") {
			gameObject.SetActive (false);
		}
	}
}
