using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateAndDeactivateAllSounds : MonoBehaviour {

	private string enablingDisablingSFXKeY = "enablingDisablingSFX";
	private string enablingDisablingMusicKey = "enablingDisablingMusic";
	private int enablingDisablingSFXValue;
	private int enablingDisablingMusic;
	private Button buttonToChangeSprites;
	private Image buttonImage;
	private SpriteState musicOn;
	private SpriteState musicOff;
	private SpriteState sFXOn;
	private SpriteState sFXOff;
	public bool checkForMusicState;
	public bool checkForSFXState;
	public Sprite disableSpriteMusicOn;
	public Sprite pressedSpriteMusicOn;
	public Sprite highLightedSpriteMusicOn;
	public Sprite disableSpriteSFXOn;
	public Sprite pressedSpriteSFXOn;
	public Sprite highLightedSpriteSFXOn;
	public Sprite disableSpriteMusicOff;
	public Sprite pressedSpriteMusicOff;
	public Sprite highLightedSpriteMusicOff;
	public Sprite disableSpriteSFXOff;
	public Sprite pressedSpriteSFXOff;
	public Sprite highLightedSpriteSFXOff;

	void Awake(){
		buttonToChangeSprites = GetComponent<Button> ();
		buttonImage = GetComponent<Image> ();
		musicOn = new SpriteState();
		musicOff = new SpriteState();
		sFXOn = new SpriteState();
		sFXOff = new SpriteState();
	}

	void Start () {
		enablingDisablingSFXValue = PlayerPrefs.GetInt (enablingDisablingSFXKeY, 1);
		enablingDisablingMusic = PlayerPrefs.GetInt (enablingDisablingMusicKey, 1);
		musicOn.disabledSprite = disableSpriteMusicOn;
		musicOn.pressedSprite = pressedSpriteMusicOn;
		musicOn.highlightedSprite = highLightedSpriteMusicOn;
		musicOff.disabledSprite = disableSpriteMusicOff;
		musicOff.pressedSprite = pressedSpriteMusicOff;
		musicOff.highlightedSprite = highLightedSpriteMusicOff;
		sFXOn.disabledSprite = disableSpriteSFXOn;
		sFXOn.pressedSprite = pressedSpriteSFXOn;
		sFXOn.highlightedSprite = highLightedSpriteSFXOn;
		sFXOff.disabledSprite = disableSpriteSFXOff;
		sFXOff.pressedSprite = pressedSpriteSFXOff;
		sFXOff.highlightedSprite = highLightedSpriteSFXOff;
	}
	

	void Update () {
		if (checkForMusicState) {
			if (enablingDisablingMusic == 0) {
				buttonImage.sprite = musicOff.disabledSprite;
				buttonToChangeSprites.spriteState = musicOff;
			} else if (enablingDisablingMusic == 1){
				buttonImage.sprite = musicOn.disabledSprite;
				buttonToChangeSprites.spriteState = musicOn;
			}
		} else if (checkForSFXState) {
			if (enablingDisablingSFXValue == 0) {
				buttonImage.sprite = sFXOff.disabledSprite;
				buttonToChangeSprites.spriteState = sFXOff;
			} else if (enablingDisablingSFXValue == 1) {
				buttonImage.sprite = sFXOn.disabledSprite;
				buttonToChangeSprites.spriteState = sFXOn;
			}
		}
	}

	public void ActivateDeactivateSFX(){
		if (enablingDisablingSFXValue == 1) {
			PlayerPrefs.SetInt (enablingDisablingSFXKeY, 0);
			enablingDisablingSFXValue = PlayerPrefs.GetInt (enablingDisablingSFXKeY);
			buttonToChangeSprites.spriteState = sFXOff;
		} else if (enablingDisablingSFXValue == 0) {
			PlayerPrefs.SetInt (enablingDisablingSFXKeY, 1);
			enablingDisablingSFXValue = PlayerPrefs.GetInt (enablingDisablingSFXKeY);
			buttonToChangeSprites.spriteState = sFXOn;
		}
	}

	public void ActivateDeactivateMusic(){
		if (enablingDisablingMusic == 1) {
			PlayerPrefs.SetInt (enablingDisablingMusicKey, 0);
			enablingDisablingMusic = PlayerPrefs.GetInt (enablingDisablingMusicKey);
		} else if (enablingDisablingMusic == 0) {
			PlayerPrefs.SetInt (enablingDisablingMusicKey, 1);
			enablingDisablingMusic = PlayerPrefs.GetInt (enablingDisablingMusicKey);
		}
	}
}
