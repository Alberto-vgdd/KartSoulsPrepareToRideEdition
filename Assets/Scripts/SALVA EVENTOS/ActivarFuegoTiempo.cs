using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarFuegoTiempo : MonoBehaviour {

	public GameObject fuego,zonaFuego;


	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			fuego.SetActive (true);
			zonaFuego.SetActive (true);
		}
	}


	
}
