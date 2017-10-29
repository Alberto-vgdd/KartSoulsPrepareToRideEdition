using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarFueguecito : MonoBehaviour 
{
	public GameObject fuego;

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			fuego.SetActive (false);
			gameObject.SetActive (false);
		}
	}
}
