using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoActivaParticulas : MonoBehaviour {

	public GameObject particulas;
	
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			particulas.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			particulas.SetActive (false);
		}
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Player") {
			particulas.SetActive (true);
		}
	}
}
