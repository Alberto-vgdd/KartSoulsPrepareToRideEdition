using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoughBehaviour : MonoBehaviour {

	private GameObject player;
	public GameObject SmoughModel;
	private Vector3 smoughVelocity;
	

	// Use this for initialization
	void Start () {
			player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(player.transform.position);
		MovementBehaviour();
		
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




}
