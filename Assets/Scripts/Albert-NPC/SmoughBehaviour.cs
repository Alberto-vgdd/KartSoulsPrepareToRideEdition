using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoughBehaviour : MonoBehaviour {

	public GameObject player;
	private PlayerMovementScript playerMovementScript;
	public GameObject SmoughModel;
	private Vector3 smoughVelocity;
	private Vector3 orpos;
	

	// Use this for initialization
	void Awake () {
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
			transform.LookAt(player.transform.position);
			MovementBehaviour();
		}

		
		//SmoughModel.transform.LookAt(player.transform.position);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		 {
			/* other.gameObject.GetComponent<Rigidbody>().AddForce(-this.transform.forward*100f,
			 													 ForceMode.VelocityChange);
			 */
		 }
	}

	void MovementBehaviour()
	{
		transform.Translate(Vector3.forward*5f*Time.deltaTime,Space.Self);
	}

	public void setOrPos()
	{
		transform.position = orpos;
	}



}
