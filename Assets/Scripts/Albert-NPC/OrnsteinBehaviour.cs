using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnsteinBehaviour : MonoBehaviour {

	private float coolDownTimer;
	[Range(10, 100)]
	public float dashForce = 10f;
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (coolDownTimer > 3.0f) // DASH!!
		{
			LockOn();
			this.GetComponent<Rigidbody>().AddForce(this.transform.forward * dashForce,
													  ForceMode.VelocityChange);
			coolDownTimer = 0.0f;

		}
		coolDownTimer += Time.deltaTime;
		MovementBehaviour();
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
			 Time.deltaTime * 2f);
	}

	void LockOn()
	{
		this.transform.LookAt(player.transform.position);
	}


}
