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
	public Transform turningPivotTransform;

	[Header("Stamina")]
	public float maxStaminaValue;
	public float staminaRecoverySpeed;
	public float accelerateStaminaCost;
	public float noStaminaSpeedMultiplier;


	// Variables to manage movement inputs
	private float forwardInput;
	private float turningInput;

	// Variables to manage movement
	private Vector3 newVelocity;
	private float forwardAcceleration;
	private float currentFowardVelocity;
	private float accelerationInfluence;


	// Variables to manage stamina
	private float currentStamina;



	private Rigidbody playerRigidbody;
	private Transform playerTransform;
	

	// Use this for initialization
	void Awake () 
	{
		playerRigidbody = GetComponent<Rigidbody>();
		playerTransform = GetComponent<Transform>();

		currentStamina = maxStaminaValue;
	}
	

	void Update () 
	{
		// Read inputs. Invert horizontal inputs in case the player is moving backward
		forwardInput = ( Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0f) ?  Mathf.Sign(Input.GetAxisRaw("Vertical")) : 0f;
		turningInput = ( forwardInput != 0) ? Input.GetAxisRaw("Horizontal") * forwardInput: Input.GetAxisRaw("Horizontal");

		// Transform the forwardInput to a acceleration value
		forwardAcceleration = Mathf.SmoothDamp(forwardAcceleration,forwardInput,ref currentFowardVelocity,acceleration);

		// Update Stamina values
		UpdateStamina();

		// Calculate how the player will turn based on its speed
		accelerationInfluence = Mathf.Clamp((1-Mathf.Abs(forwardAcceleration)),minAccelerationInfluence,1f)*Mathf.Clamp01(Vector3.Scale(playerRigidbody.velocity,turningPivotTransform.forward).magnitude/maxPlayerSpeed);
		
		// Rotate the player 
		turningPivotTransform.Rotate(playerTransform.up,accelerationInfluence*turningInput*maxPlayerRotationAngle*Time.deltaTime);
		
		// Set the new movement velocity
		if (currentStamina > 0)
		{
			newVelocity = turningPivotTransform.forward*forwardAcceleration*maxPlayerSpeed;
		}
		else
		{
			newVelocity = turningPivotTransform.forward*forwardAcceleration*maxPlayerSpeed*noStaminaSpeedMultiplier;
		}
		
		playerRigidbody.velocity = newVelocity + Vector3.up*playerRigidbody.velocity.y;
		playerRigidbody.AddForce(Physics.gravity,ForceMode.Acceleration);
	}


	void UpdateStamina()
	{
		if (Mathf.Abs(forwardAcceleration) < 0.1f)
		{
			currentStamina += staminaRecoverySpeed*Time.deltaTime;
		}
		else
		{
			currentStamina -= accelerateStaminaCost*Time.deltaTime;
		}

		currentStamina = Mathf.Clamp(currentStamina,0f,maxStaminaValue);
		Debug.Log((int)currentStamina + "/" + (int)maxStaminaValue);
	}
}
