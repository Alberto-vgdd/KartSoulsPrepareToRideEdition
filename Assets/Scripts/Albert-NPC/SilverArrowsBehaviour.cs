using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverArrowsBehaviour : MonoBehaviour {

	

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		 {
			 other.gameObject.GetComponent<Rigidbody>().AddForce(-this.transform.forward*100f,
			 													 ForceMode.VelocityChange);
			 Destroy(this);
		 }
		else
		{
			Destroy(this);
		}
	}





}
