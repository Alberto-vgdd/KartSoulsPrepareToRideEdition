using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoTocandoAlgo : MonoBehaviour {

	public AudioClip sound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = sound;
	}

	// Update is called once per frame
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			audioSource.Play ();
		}
	}
}
