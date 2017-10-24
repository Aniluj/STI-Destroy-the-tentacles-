using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatController : MonoBehaviour {

	public Transform neededPositionForTheSlider;
	public Slider overheatSlider;
	public float incrementPerShot;
	public float decrementPerTime;
	private Shoot[] shooting;


	void Awake(){
		shooting = GetComponents<Shoot>();
	}
		
	void Update () {
		overheatSlider.transform.rotation = neededPositionForTheSlider.rotation;
		overheatSlider.transform.position = neededPositionForTheSlider.position;

		if (shooting [0].shooting == true || shooting [1].shooting == true) {
			overheatSlider.value += incrementPerShot;
		} 
		if(shooting[0].shooting == false || shooting[1].shooting == false){
			overheatSlider.value -= decrementPerTime;
		}
		if (overheatSlider.value >= overheatSlider.maxValue) {
			shooting [0].isOverHeated = true;
			shooting [1].isOverHeated = true;
		} else if(overheatSlider.value <= overheatSlider.maxValue - 1){
			shooting [0].isOverHeated = false;
			shooting [1].isOverHeated = false;
		}
	}
}
