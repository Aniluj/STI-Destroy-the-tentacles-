using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody2D bullet;
	private Collider2D bulletCollider;
	public float velocity;

	void Awake (){
		bullet = GetComponent<Rigidbody2D> ();
		bulletCollider = GetComponent<Collider2D> ();
	}

	void Start () {
		
	}

	void Update () {
		bullet.AddRelativeForce (Vector2.up * velocity * -1);
	}

	void FixedUpdate (){
		
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Tentacle" || coll.gameObject.name == "Contention shield") {
			gameObject.SetActive (false);
		}
		if (coll.gameObject.tag == "Bullet" || coll.gameObject.name == "Spaceship") {
			Physics2D.IgnoreCollision (bulletCollider, coll.collider);
		}
	}
}
