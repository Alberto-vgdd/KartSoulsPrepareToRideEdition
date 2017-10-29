using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoTocandoJugador : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			audioSource.Play ();
		}
	}
}
