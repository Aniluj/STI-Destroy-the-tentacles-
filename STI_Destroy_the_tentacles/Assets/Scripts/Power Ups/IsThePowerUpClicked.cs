using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThePowerUpClicked : MonoBehaviour {

	public bool isClicked;

	void Start () {
		isClicked = false;
	}

	void Update () {
		
	}

	void OnMouseDown(){
		isClicked = true;
	}
}
