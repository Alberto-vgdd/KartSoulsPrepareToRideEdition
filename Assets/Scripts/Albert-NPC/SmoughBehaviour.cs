using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoughBehaviour : MonoBehaviour {

	private GameObject player;
	public GameObject SmoughModel;
	

	// Use this for initialization
	void Start () {
			player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		MovementBehaviour();
		//transform.LookAt(player.transform.position);
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
		this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position,
			 Time.deltaTime * 1.5f);
	}




}
