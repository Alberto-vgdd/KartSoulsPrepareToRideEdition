using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoltarObstaculo : MonoBehaviour {

	public GameObject[] obstaculos;
	public ParticleSystem particulas;
	public AudioClip sound;
	AudioSource audioSource;

	void Start(){
		if (sound != null) {
			audioSource = GetComponent<AudioSource> ();
			audioSource.clip = sound;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			foreach (GameObject objeto in obstaculos) {
				if(objeto == null) return;
				objeto.GetComponent<Rigidbody> ().isKinematic = false;
				Destroy(objeto,10f);
			}

			if (particulas != null){
				particulas.Play();
			}

			if (sound != null) {
				audioSource.Play ();
			}
		}


	}
}
