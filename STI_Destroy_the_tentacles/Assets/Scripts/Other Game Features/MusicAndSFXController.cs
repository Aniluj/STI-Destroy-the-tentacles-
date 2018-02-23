using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSFXController : MonoBehaviour {

	private string enablingDisablingSFXKeY = "enablingDisablingSFX";
	private string enablingDisablingMusicKey = "enablingDisablingMusic";
	private int enablingDisablingSFXValue;
	private int enablingDisablingMusic;
	public bool checkInUpdate;
	public AudioSource[] music;
	public AudioSource[] sFX;

	void Start () {
		enablingDisablingMusic = PlayerPrefs.GetInt (enablingDisablingMusicKey);
		enablingDisablingSFXValue = PlayerPrefs.GetInt (enablingDisablingSFXKeY);
		if (enablingDisablingMusic == 1 && music != null) {
			for (int i = 0; i < music.Length; i++) {
				music [i].volume = 1f;
			}
		} else if (enablingDisablingMusic == 0 && music != null) {
			for (int i = 0; i < music.Length; i++) {
				music [i].volume = 0f;
			}
		}
		if (enablingDisablingSFXValue == 1 && sFX != null) {
			for (int i = 0; i < sFX.Length; i++) {
				sFX [i].volume = 1f;
			}
		} else if (enablingDisablingSFXValue == 0 && sFX != null) {
			for (int i = 0; i < sFX.Length; i++) {
				sFX [i].volume = 0f;
			}
		}
	}

	void Update() {
		if (checkInUpdate) {
			enablingDisablingMusic = PlayerPrefs.GetInt (enablingDisablingMusicKey);
			enablingDisablingSFXValue = PlayerPrefs.GetInt (enablingDisablingSFXKeY);
			if (enablingDisablingMusic == 1 && music != null) {
				for (int i = 0; i < music.Length; i++) {
					music [i].volume = 1f;
				}
			} else if (enablingDisablingMusic == 0 && music != null) {
				for (int i = 0; i < music.Length; i++) {
					music [i].volume = 0f;
				}
			}
			if (enablingDisablingSFXValue == 1 && sFX != null) {
				for (int i = 0; i < sFX.Length; i++) {
					sFX [i].volume = 1f;
				}
			} else if (enablingDisablingSFXValue == 0 && sFX != null) {
				for (int i = 0; i < sFX.Length; i++) {
					sFX [i].volume = 0f;
				}
			}
		}
	}
}
