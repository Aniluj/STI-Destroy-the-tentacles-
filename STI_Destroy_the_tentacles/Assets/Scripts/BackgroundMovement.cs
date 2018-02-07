using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

	public Transform transformOfBackground1;
	public Transform transformOfBackground2;
	public Transform position1;
	public Transform position2;
	public float velocity;


	void Update () {
		transformOfBackground1.Translate (Vector3.right * velocity * Time.deltaTime);
		transformOfBackground2.Translate (Vector3.right * velocity * Time.deltaTime);
		if (transformOfBackground1.position.x >= position1.position.x) {
			transformOfBackground1.localPosition = position2.localPosition;
		} else if (transformOfBackground2.position.x >= position1.position.x) {
			transformOfBackground2.localPosition = position2.localPosition;
		}
	}
}
