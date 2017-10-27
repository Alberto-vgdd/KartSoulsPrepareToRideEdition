using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour 
{
	[Header("Player Parameters")]
	public float maxPlayerSpeed;
	public float maxPlayerRotationAngle;
	public float acceleration;
	public float minAccelerationInfluence;

	[Header("Turning Pivot")]
	public Transform turningPivot;


	// Variables to manage movement inputs
	private float forwardInput;
	private float turningInput;

	// Variables to manage movement
	private Vector3 newVelocity;
	private float forwardAcceleration;
	private float currentFowardVelocity;
	private float accelerationInfluence;



	private Rigidbody playerRigidbody;
	private Transform playerTransform;
	

	// Use this for initialization
	void Awake () 
	{
		playerRigidbody = GetComponent<Rigidbody>();
		playerTransform = GetComponent<Transform>();
	}
	

	void Update () 
	{
		// Read inputs. Invert horizontal inputs in case the player is moving backward
		forwardInput = ( Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.4f) ?  Mathf.Sign(Input.GetAxisRaw("Vertical")) : 0f;
		turningInput = ( forwardInput != 0) ? Input.GetAxisRaw("Horizontal") * forwardInput: Input.GetAxisRaw("Horizontal");

		// Transform the forwardInput to a acceleration value
		forwardAcceleration = Mathf.SmoothDamp(forwardAcceleration,forwardInput,ref currentFowardVelocity,acceleration);

		// Calculate how the player will turn based on its speed
		accelerationInfluence = Mathf.Clamp((1-Mathf.Abs(forwardAcceleration)),minAccelerationInfluence,1f);

		// Rotate the player.
		turningPivot.Rotate(playerTransform.up,accelerationInfluence*turningInput*maxPlayerRotationAngle*Time.deltaTime);

		// Set the new movement velocity
		newVelocity = turningPivot.forward*forwardAcceleration*maxPlayerSpeed;


		playerRigidbody.velocity = newVelocity;
	}
}
