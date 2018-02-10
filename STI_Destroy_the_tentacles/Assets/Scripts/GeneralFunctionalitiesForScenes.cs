﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralFunctionalitiesForScenes : MonoBehaviour {

	public string sceneName;
	public bool detectAnyKey;
	public CanvasGroup[] canvasGroupToDisable;
	public CanvasGroup[] canvasGroupToEnable;
	public float velocityOfDisableAndEnable;

	void Update(){
		if (detectAnyKey) {
			if (Input.anyKeyDown) {
				detectAnyKey = false;
				ChangeBetweenCanvasGroup ();
			}
		}
	}

	public void ChangeOfScene(){
		Time.timeScale = 1;
		SceneManager.LoadScene (sceneName);
	}

	public void Exit(){
		Application.Quit ();
	}

	public void ChangeBetweenCanvasGroup(){
		for (int i = 0; i < canvasGroupToDisable.Length; i++) {
			canvasGroupToDisable [i].interactable = !canvasGroupToDisable [i].interactable;
			canvasGroupToDisable [i].blocksRaycasts = !canvasGroupToDisable [i].blocksRaycasts;
		}
		StartCoroutine (Fade (canvasGroupToDisable, canvasGroupToEnable, velocityOfDisableAndEnable));
	}

	private IEnumerator Fade(CanvasGroup[] canvasGroupToDisable, CanvasGroup[] canvasGroupToEnable, float velocityOfDisableOrEnable){
		while (canvasGroupToDisable [canvasGroupToDisable.Length - 1].alpha > 0f) {
			for (int i = 0; i < canvasGroupToDisable.Length; i++) {
				canvasGroupToDisable [i].alpha -= velocityOfDisableOrEnable;
			}
			yield return null;
		}
		while (canvasGroupToEnable [canvasGroupToEnable.Length - 1].alpha < 1f) {
			for (int i = 0; i < canvasGroupToEnable.Length; i++) {
				canvasGroupToEnable [i].alpha += velocityOfDisableOrEnable;
			}
			yield return null;
		}
		for (int i = 0; i < canvasGroupToEnable.Length; i++) {
			canvasGroupToEnable [i].interactable = !canvasGroupToEnable [i].interactable;
			canvasGroupToEnable [i].blocksRaycasts = !canvasGroupToEnable [i].blocksRaycasts;
		}
	}
}
