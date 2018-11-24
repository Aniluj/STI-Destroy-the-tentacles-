using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundMovement : MonoBehaviour {
    public float Speed;

    private Image image;
    private Vector2 offset;
	void Awake () {
        image = GetComponent<Image>();
    }
    void Start()
    {
        image.mainTexture.wrapModeU = TextureWrapMode.Repeat;
        offset.y = image.material.mainTextureOffset.y;
    }

    void Update () {
        offset.x -= Time.deltaTime * Speed;
        image.material.mainTextureOffset = offset;
    }
}
