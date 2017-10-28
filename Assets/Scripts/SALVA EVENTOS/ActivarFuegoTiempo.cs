using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarFuegoTiempo : MonoBehaviour {

	public GameObject fuego,muerte;
	public float tiempo;
	// Use this for initialization
	void Start () {
		tiempo = 0;
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Player") {
			tiempo += Time.deltaTime;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			tiempo = 0;
			fuego.SetActive (false);
			muerte.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (tiempo > 5) {
			fuego.SetActive (true);
		}
		if (tiempo > 7) {
			muerte.SetActive (true);
		}
	}
}
