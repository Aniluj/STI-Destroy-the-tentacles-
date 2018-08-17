using UnityEngine;

public class PowerUpToucheable : MonoBehaviour
{

	public PowerUpsController PowerUpsController;
	
	public void OnMouseDown()
	{
		PowerUpsController.NotifyPowerUpTouch();
	}
}
