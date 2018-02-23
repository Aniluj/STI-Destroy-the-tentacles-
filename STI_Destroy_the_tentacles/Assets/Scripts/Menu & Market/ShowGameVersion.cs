using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowGameVersion : MonoBehaviour {

	public TextMeshProUGUI gameVersionText;

	void Start () {
		gameVersionText.text = Application.version;
	}
}
