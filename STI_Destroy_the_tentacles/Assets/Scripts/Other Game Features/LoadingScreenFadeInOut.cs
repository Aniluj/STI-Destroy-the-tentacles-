using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenFadeInOut : MonoBehaviour {

	private bool activateFadeOut = true;
	private CanvasGroup[] loadingScreenToFade;
	private GeneralFunctionalitiesForScenes generalFunctionalitiesForUseTheFade;
	public bool activateFadeIn;
	public CanvasGroup[] canvasGroupToDisable;
	public InGamePause inGamePauseScript;

	void Awake(){
		loadingScreenToFade = GetComponents<CanvasGroup> ();
		generalFunctionalitiesForUseTheFade = GetComponent<GeneralFunctionalitiesForScenes> ();
	}

	void Start () {
		
	}

	void Update () {
		if (activateFadeOut) {
			activateFadeOut = false;
			StartCoroutine (generalFunctionalitiesForUseTheFade.Fade (loadingScreenToFade, null, generalFunctionalitiesForUseTheFade.velocityOfDisableAndEnable));
		} else if (activateFadeIn) {
			if (inGamePauseScript != null) {
				inGamePauseScript.enabled = false;
			}
			activateFadeIn = false;
			StartCoroutine (generalFunctionalitiesForUseTheFade.Fade (null, loadingScreenToFade, generalFunctionalitiesForUseTheFade.velocityOfDisableAndEnable));
		} else if (loadingScreenToFade [loadingScreenToFade.Length - 1].alpha >= 1 && generalFunctionalitiesForUseTheFade.sceneName != "") {
			generalFunctionalitiesForUseTheFade.ChangeOfScene ();
		}
	}
}
