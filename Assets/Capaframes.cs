using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capaframes : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision obj)
	{
		if (obj.collider.CompareTag("Player"))
		{
			Application.targetFrameRate = 10;
		}
	}
}
