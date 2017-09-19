using UnityEngine;

public class SpaceshipMovement : MonoBehaviour {

	private float horizontalAxis;
	private float verticalAxis;
	private Rigidbody2D spaceship;
	public float velocity;

	void Awake (){
		spaceship = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		
	}

	void Update () {
		horizontalAxis = Input.GetAxisRaw ("Horizontal");
		verticalAxis = Input.GetAxisRaw ("Vertical");
	}

	void FixedUpdate(){
		spaceship.MovePosition (transform.position + transform.up * horizontalAxis * Time.fixedDeltaTime * velocity);
	}
}
