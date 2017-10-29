using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPorton : MonoBehaviour {

	public GameObject puerta;
	public Animator puertaAnimacion;
	public AnimationClip animacion;
	public bool primeraVez = true;

	void Start(){
	}

	void Update(){
		
	}

	void OnTriggerExit(Collider col){
		if (animacion.isLooping) {
			puertaAnimacion.speed = 0.5f;
		}
		if (col.tag == "Player") {
			puertaAnimacion.SetTrigger ("Activado");
			primeraVez = false;
		}

	}
}
