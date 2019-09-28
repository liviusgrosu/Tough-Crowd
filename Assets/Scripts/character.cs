using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]


public class character : MonoBehaviour
{

	CharacterController cc;

	public float verticalVelocity = 0;
	public float movementSpeed = 10f;
	public float jumpSpeed = 20.0f;


    public float delay;

	public GameObject left_side;
	public GameObject right_side;
	public GameObject middle_side;

	bool on_left;
	bool on_right;

	float side_time = 2.0f;

	float airForwardSpeed;
	float forwardSpeed;
	float acc;
	Vector3 speed;

	public GameObject normal_sword_hitbox;

	// Use this for initialization
	void Start()
	{
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();

        side_time = delay;


        transform.position = middle_side.transform.position;

		on_left = false;
		on_right = false;

		airForwardSpeed = 0.0f;
		speed = new Vector3(0, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		movement(movementSpeed, delay);
	}
	void movement(float movementForwardSpeed, float movementSideSpeed)
	{
		//forwardSpeed = Input.GetAxis("Vertical") * movementForwardSpeed * acc * movementSideSpeed;

		//print ("on_left: " + on_left + " | on_right: " + on_right);

		if (on_left || on_right) {
			side_time -= Time.deltaTime;
		} 

		if(side_time <= 0.0f)
		{
			side_time = movementSideSpeed;
			on_left = false;
			on_right = false;
			transform.position = middle_side.transform.position;
		}

		if (Input.GetKeyDown ("left") && !on_left && !on_right) {
			on_left = true;
			transform.position = left_side.transform.position;
		}
		if (Input.GetKeyDown ("right") && !on_left && !on_right) {
			on_right = true;
			transform.position = right_side.transform.position;
		}
			
		if (!isGrounded())
			verticalVelocity += (Physics.gravity.y * 4.0f) * Time.deltaTime;
		else
			verticalVelocity = 0.0f;
		speed = new Vector3(0, verticalVelocity, 0);

		speed = transform.rotation * speed;

		cc.Move(speed * Time.deltaTime);
	}
	public bool isGrounded()
	{
		return cc.isGrounded;
	}
}
