using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralFunctionalitiesForScenes : MonoBehaviour {

    public string sceneName;
    public bool detectAnyKey;
    public bool enableToChange;
    public RectTransform titleTransform;
    public RectTransform positionOfTheTitleToReach;
    public CanvasGroup[] canvasGroupToDisable;
    public CanvasGroup[] canvasGroupToEnable;
    public GeneralFunctionalitiesForScenes generalFunctionalitiesScriptOfLoadinScreen;
    public float velocityOfDisableAndEnable;
    public float velocityOfElevation;
    public LoadingScreenFadeInOut scriptToActivateFade;
    private Button buttonToChangeTheSprite;

    void Awake() {
        buttonToChangeTheSprite = GetComponent<Button>();
    }

    void Update() {
        if(detectAnyKey) {
            if(Input.anyKeyDown) {
                detectAnyKey = false;
                UpdateTitlePosition();
                ChangeBetweenCanvasGroup();
            }
        }
    }

    public void ActivateFadeInOfLoadingScreen() {
        generalFunctionalitiesScriptOfLoadinScreen.sceneName = sceneName;
        scriptToActivateFade.activateFadeIn = true;
    }

    public void ChangeOfScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void Exit() {
        Application.Quit();
    }

    public void UpdateTitlePosition() 
    {
        StartCoroutine(Elevate(positionOfTheTitleToReach, titleTransform));
    }

	public void ChangeBetweenCanvasGroup(){
		if (enableToChange) {
			for (int i = 0; i < canvasGroupToDisable.Length; i++) {
				canvasGroupToDisable [i].interactable = !canvasGroupToDisable [i].interactable;
				canvasGroupToDisable [i].blocksRaycasts = !canvasGroupToDisable [i].blocksRaycasts;
			}
			StartCoroutine (Fade (canvasGroupToDisable, canvasGroupToEnable, velocityOfDisableAndEnable));
		}
	}

    public IEnumerator Elevate(RectTransform positionOfTheTitleToReach, RectTransform titleTransform)
    {
        while(titleTransform.position.y < positionOfTheTitleToReach.position.y)
        {
            titleTransform.position += new Vector3(0, velocityOfElevation, 0);
            Debug.Log(titleTransform.position.y);
            yield return null;
        }
    }

	public IEnumerator Fade(CanvasGroup[] canvasGroupToDisable, CanvasGroup[] canvasGroupToEnable, float velocityOfDisableOrEnable){
		if (canvasGroupToDisable != null) {
			while (canvasGroupToDisable [canvasGroupToDisable.Length - 1].alpha > 0f) {
				for (int i = 0; i < canvasGroupToDisable.Length; i++) {
					canvasGroupToDisable [i].alpha -= velocityOfDisableOrEnable;
				}
				yield return null;
			}
		}
		if (canvasGroupToEnable != null) {
			while (canvasGroupToEnable [canvasGroupToEnable.Length - 1].alpha < 1f) {
				for (int i = 0; i < canvasGroupToEnable.Length; i++) {
					canvasGroupToEnable [i].alpha += velocityOfDisableOrEnable;
				}
				yield return null;
			}
		}
		if (canvasGroupToEnable != null) {
			for (int i = 0; i < canvasGroupToEnable.Length; i++) {
				canvasGroupToEnable [i].interactable = !canvasGroupToEnable [i].interactable;
				canvasGroupToEnable [i].blocksRaycasts = !canvasGroupToEnable [i].blocksRaycasts;
			}
		}
	}
}
