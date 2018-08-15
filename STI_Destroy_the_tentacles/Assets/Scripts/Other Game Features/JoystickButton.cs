using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour , IPointerDownHandler,IPointerUpHandler
{

	public bool IsPressed = false;
	public bool IsButtonDown = false;
	public bool IsButtonUp = false;
	
	public void OnPointerDown(PointerEventData eventData)
	{
		IsPressed = true;
		IsButtonDown = true;
		Invoke("ButtonDownBackToFalse", 0.0f);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		IsPressed = false;
		IsButtonUp = true;
		Invoke("ButtonUpBackToFalse", 0.0f);
	}

	private void ButtonDownBackToFalse()
	{
		IsButtonDown = false;
	}

	private void ButtonUpBackToFalse()
	{
		IsButtonUp = false;
	}
	
}
