using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardTriggers : MonoBehaviour {


	public int triggerID;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (triggerID == 1 && other.tag == "Player")
		{

		}
		if (triggerID == 2 && other.tag == "Player")
		{
			
		}
		if (triggerID == 3 && other.tag == "Player")
		{
			
		}
	}


}
