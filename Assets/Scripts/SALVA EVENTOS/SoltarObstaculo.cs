using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoltarObstaculo : MonoBehaviour {

	public GameObject[] obstaculos;
	public ParticleSystem particulas;

	void Start(){
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			foreach (GameObject objeto in obstaculos) {
				objeto.GetComponent<Rigidbody> ().isKinematic = false;
			}

			if (particulas != null){
				particulas.Play();
			}
		}


	}
}
