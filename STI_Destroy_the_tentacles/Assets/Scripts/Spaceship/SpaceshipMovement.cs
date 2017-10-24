using UnityEngine;

public class SpaceshipMovement : MonoBehaviour {

	private float horizontalAxis;
	private Rigidbody2D spaceship;
	public float velocity;
	public Transform objectToRotateAround;

	void Awake (){
		spaceship = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		
	}

	void Update () {
		horizontalAxis = Input.GetAxisRaw ("Horizontal") * -1f;

	}

	void FixedUpdate(){
		RotateAround (objectToRotateAround.position, velocity * horizontalAxis * Time.deltaTime, spaceship);
	}

	public static void RotateAround(Vector3 planetPosition, float velocity, Rigidbody2D spaceship){
		Quaternion rotation = Quaternion.AngleAxis (velocity, Vector3.forward);
		Vector3 direction = spaceship.transform.position - planetPosition;
	
		direction = rotation * direction;
		Vector2 newPosition = planetPosition + direction;
		spaceship.transform.right = direction * -1;
		spaceship.MovePosition (newPosition);
	}
}
