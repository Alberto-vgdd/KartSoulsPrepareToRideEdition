using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnsteinBehaviour : MonoBehaviour {

	private float coolDownTimer;
	[Range(30, 100)]
	public float dashForce = 30f;
	public GameObject player;
	private PlayerMovementScript playerMovementScript;
		private Vector3 orpos;

	public GameObject model;

	// Use this for initialization
	void Awake () 
	{

		playerMovementScript = player.GetComponent<PlayerMovementScript>();
		orpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		


		if (playerMovementScript.isPlayerDead())
		{
				 setOrPos();
			gameObject.SetActive(false);
		}
		else
		{
			LockOn();
			if (coolDownTimer > 3.0f) // DASH!!
			{			
				this.GetComponent<Rigidbody>().AddForce(this.transform.forward * dashForce,
														ForceMode.VelocityChange);
				coolDownTimer = 0.0f;
			}
			coolDownTimer += Time.deltaTime;
			MovementBehaviour();
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		 {
			 other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward*100f,
			 													 ForceMode.VelocityChange);
		 }
	}

	void MovementBehaviour()
	{
		this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position,
			 Time.deltaTime * 4f);
	}

	void LockOn()
	{
		//transform.LookAt(new Vector3(player.transform.position.x, 0f, 
		//							player.transform.position.z));
		transform.LookAt(player.transform.position);
	}

	public void setOrPos()
	{
		transform.position = orpos;
	}


}
