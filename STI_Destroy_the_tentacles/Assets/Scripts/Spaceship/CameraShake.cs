using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public float shakeTimer;
	public float shakeAmount;
	public Vector2 shakePos;
	public bool cameraShakeActivated;
	private CameraFollow cameraFollowScript;
	private int timesActivated;

	void Awake(){
		cameraFollowScript = GetComponent<CameraFollow> ();
	}

	void Update () {
		if (cameraShakeActivated) {
			cameraFollowScript.enabled = false;
			cameraShakeActivated = false;
			ActivateCameraShake (0.3f, 1f);
		}
		if (shakeTimer > 0) {
			shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;
		}
	}

	public void ActivateCameraShake(float shakePower, float shakeDuration){
		shakeAmount = shakePower;
		shakeTimer = shakeDuration;
	}
}
