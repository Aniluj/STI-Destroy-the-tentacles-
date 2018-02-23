using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatController : MonoBehaviour {

	public Transform neededPositionForTheSlider;
	public Slider overheatSlider;
	public float incrementPerShot;
	public float decrementPerTime;
	private Shoot shooting;


	void Awake(){
		shooting = GetComponent<Shoot>();
	}
		
	void Update () {
		overheatSlider.transform.rotation = neededPositionForTheSlider.rotation;
		overheatSlider.transform.position = neededPositionForTheSlider.position;

		if (shooting.shooting == true) {
			overheatSlider.value += incrementPerShot;
		} 
		if(shooting.shooting == false){
			overheatSlider.value -= decrementPerTime;
		}
		if (overheatSlider.value >= overheatSlider.maxValue) {
			shooting.isOverHeated = true;
		} else if(overheatSlider.value <= overheatSlider.maxValue - 1){
			shooting.isOverHeated = false;
		}
	}
}
