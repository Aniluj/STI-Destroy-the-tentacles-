using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	private bool firstShoot;
	private float timer;
	public float cooldown;
	public GameObject[] bullet;
	public Transform shootingPoint;

	void Awake (){
		
	}

	void Start () {
		firstShoot = true;
	}

	void Update () {
		timer += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space) && (firstShoot || timer > cooldown)) {
			timer = 0;
			firstShoot = false;
			for(int i = 0; i < 10; i++){
				if (bullet [i].activeInHierarchy == false) {
					Debug.Log ("asd");
					bullet [i].transform.SetPositionAndRotation (shootingPoint.position, shootingPoint.rotation);
					bullet [i].SetActive (true);
					break;
				}
			}
			//Instantiate (bullet, shootingPoint.position, shootingPoint.rotation);
		}
	}

	void FixedUpdate (){
		
	}
}
