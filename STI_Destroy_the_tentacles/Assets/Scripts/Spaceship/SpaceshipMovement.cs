using System.Security.Cryptography;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour {

	private float horizontalAxis;
	private Rigidbody2D spaceship;
	private float timer;
	private Animator spaceshipAnimator;
	public float velocity;
	public Transform objectToRotateAround;

	private FloatingJoystick touchJoystick;

	void Awake (){
		spaceshipAnimator = GetComponent<Animator> ();
		spaceship = GetComponent<Rigidbody2D> ();
	}

	void Start ()
	{
		touchJoystick = GameObject.FindGameObjectWithTag("TouchJoystick").GetComponent<FloatingJoystick>();
	}

	public float HorizontalAxis()
	{
		return horizontalAxis;
	}

	void Update () {
		
		horizontalAxis = Input.GetAxisRaw ("Horizontal") * -1f;
		//TouchMovement
		if (touchJoystick != null)
		{
			if (touchJoystick.Horizontal > 0.0f)
			{
				horizontalAxis = 1.0f * -1.0f;
			}else if (touchJoystick.Horizontal < 0.0f)
			{
				horizontalAxis = -1.0f * -1.0f;				
			}
		}
		//TouchMovement
		
		spaceshipAnimator.SetFloat ("LeftOrRight", horizontalAxis);
		if (horizontalAxis == 0f) {
			spaceshipAnimator.SetInteger ("Idle", 0);
		} else {
			spaceshipAnimator.SetInteger ("Idle", 1);
		}
	}

	void FixedUpdate(){
		RotateAround (objectToRotateAround.position, velocity * horizontalAxis * Time.deltaTime, spaceship);
	}

	public static void RotateAround(Vector3 planetPosition, float velocity, Rigidbody2D spaceship){
		Quaternion rotation = Quaternion.AngleAxis (velocity, Vector3.forward);
		Vector3 direction = spaceship.transform.position - planetPosition;
	
		direction = rotation * direction;
		Vector2 newPosition = planetPosition + direction;
		spaceship.transform.up = direction * 1;
		spaceship.MovePosition (newPosition);
	}
}
