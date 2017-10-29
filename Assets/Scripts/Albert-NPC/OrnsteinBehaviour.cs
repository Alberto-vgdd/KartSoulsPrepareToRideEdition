using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnsteinBehaviour : MonoBehaviour {

	private float coolDownTimer;
	[Range(30, 100)]
	public float dashForce = 30f;
	private GameObject player;

	public GameObject model;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	//transform.LookAt(new Vector3(player.transform.position.x, 0f, 
	//								player.transform.position.z));
		
	}
	
	// Update is called once per frame
	void Update () 
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


}
