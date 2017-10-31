using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour 
{
	[Header("Player Movement Parameters")]
	public float maxPlayerSpeed;
	public float maxPlayerRotationAngle;
	public float acceleration;
	public float minAccelerationInfluence;

	[Header("Auxiliar Pivot Transform")]
	public Transform turningPivotTransform;
	public Transform inclinationPivotTransfrom;

	[Header("Wall/Floor Colliding parameters")]
	public LayerMask scenarioLayer;
	private CapsuleCollider playerCapsuleCollider;


	[Header("Stamina Parameters")]
	public float maxStaminaValue;
	public float staminaRecoverySpeed;
	public float accelerateStaminaCost;
	public float noStaminaSpeedMultiplier;

	[Header("Life Parameters")]
	public float maxLifeValue;


	[Header("Scripts")]
	public CanvasValues hudScript;
	public CheckpointSystem checkpointSystem;



	// Variables to manage movement inputs
	private float forwardInput;
	private float turningInput;

	// Variables to manage movement
	private Vector3 newVelocity;
	private float defaultPlayerSpeed;
	private float forwardAcceleration;
	private float currentFowardVelocity;
	private float accelerationInfluence;


	// Variables to manage stamina
	private float currentStamina;

	// Variable to manage life
	private float currentLife;


	// Variables to manage air control
	private Vector3 airControlVelocity;

	// Variables to manage Wall Collisions
	float radius;
	Vector3 point1;
	Vector3 point2;
	Vector3 direction;
	RaycastHit hitInfo;



	private Rigidbody playerRigidbody;
	private Transform playerTransform;
	

	// Use this for initialization
	void Awake () 
	{
		playerRigidbody = GetComponent<Rigidbody>();
		playerTransform = GetComponent<Transform>();
		playerCapsuleCollider = GetComponent<CapsuleCollider>();

		currentStamina = maxStaminaValue;
		currentLife = maxLifeValue;
		hudScript.SetMaxStaminaBarValue((int)maxStaminaValue);
		hudScript.SetMaxLifebarValue((int)maxLifeValue);

		radius = playerCapsuleCollider.radius;

		defaultPlayerSpeed = maxPlayerSpeed;
	}
	
	void Update()
	{
		// Update Stamina values
		UpdateStamina();
	}

	void FixedUpdate () 
	{

		// Read inputs. Invert horizontal inputs in case the player is moving backward
		forwardInput = ( Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0f) ?  Mathf.Sign(Input.GetAxisRaw("Vertical")) : 0f;
		turningInput = ( forwardInput != 0) ? Input.GetAxisRaw("Horizontal") * forwardInput: Input.GetAxisRaw("Horizontal");

		// Transform the forwardInput to a acceleration value
		forwardAcceleration = Mathf.SmoothDamp(forwardAcceleration,forwardInput,ref currentFowardVelocity,acceleration);


		// Calculate how the player will turn based on its speed
		accelerationInfluence = Mathf.Clamp((1-Mathf.Abs(forwardAcceleration)),minAccelerationInfluence,1f)*Mathf.Clamp01(Vector3.Scale(playerRigidbody.velocity,turningPivotTransform.forward).magnitude/maxPlayerSpeed);
		

		// Rotate the player 
		turningPivotTransform.Rotate(Vector3.up ,accelerationInfluence*turningInput*maxPlayerRotationAngle*Time.fixedDeltaTime,Space.Self);
		

		// Set the new movement velocity based on stamina
		if (currentStamina > 0)
		{
			newVelocity = Vector3.Scale(turningPivotTransform.forward, new Vector3(1,0,1))*forwardAcceleration*maxPlayerSpeed;
		}
		else
		{
			newVelocity =  Vector3.Scale(turningPivotTransform.forward, new Vector3(1,0,1))*forwardAcceleration*maxPlayerSpeed*noStaminaSpeedMultiplier;
		}



		// Avoid wall collision and slopes climbing
		direction = newVelocity.normalized;
		if (Physics.CapsuleCast(point1,point2,radius,direction,out hitInfo,1f, scenarioLayer.value))
		{
			if (Vector3.Angle(Vector3.up,hitInfo.normal) > 45f)
			{
				newVelocity -= Vector3.Project(newVelocity,Vector3.Scale(hitInfo.normal, new Vector3(1,0,1)));
			}
		}
		


		// Calculate velocity direction
		playerRigidbody.velocity = newVelocity + Vector3.up*(playerRigidbody.velocity.y);


		// Inclinate the kart 
		point1 =  playerTransform.position + playerCapsuleCollider.center + Vector3.up*(playerCapsuleCollider.height/2-playerCapsuleCollider.radius);
		point2 = playerTransform.position + playerCapsuleCollider.center + Vector3.up*(-playerCapsuleCollider.height/2+playerCapsuleCollider.radius);
		direction = Vector3.down;

		// Check if grounded, then interpolate the inclination
		if (Physics.CapsuleCast(point1,point2,radius*0.9f,direction,out hitInfo,0.1f,scenarioLayer.value))
		{
			
			if (hitInfo.normal != Vector3.up)
			{
				playerRigidbody.velocity  = Vector3.ProjectOnPlane(playerRigidbody.velocity ,hitInfo.normal);
			}

			inclinationPivotTransfrom.up = 	Vector3.SmoothDamp(inclinationPivotTransfrom.up, hitInfo.normal, ref airControlVelocity, 0.1f);
		}
		else
		{
			inclinationPivotTransfrom.up = 	Vector3.SmoothDamp(inclinationPivotTransfrom.up, Vector3.up, ref airControlVelocity, 0.25f);
		}

		// Add gravity
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
		hudScript.SetStaminaBarValue((int)currentStamina);

	}

	void UpdateLife()
	{
		hudScript.SetLifebarValue((int)currentLife);
	}


	public void ApplyLife(float life)
	{
		currentLife = Mathf.Clamp(currentLife+life,0f,maxLifeValue) ;
		UpdateLife();
	}
	
	public bool isPlayerDead()
	{
		return currentLife <= 0;
	}


	public void ApplyStamina(float stamina)
	{
		currentStamina = Mathf.Clamp(currentStamina+stamina,0f,maxStaminaValue) ;
		UpdateStamina();
	}

	public void SetSpeed(float newSpeed)
	{
		maxPlayerSpeed = newSpeed;
	}

	public void SetDefaultSpeed()
	{
		maxPlayerSpeed = defaultPlayerSpeed;
	}

	public float GetNormalizedAcceleration()
	{
		return Mathf.Abs(forwardAcceleration);
	}


}
