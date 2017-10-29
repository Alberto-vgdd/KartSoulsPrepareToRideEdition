using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPinchos : MonoBehaviour {

	public GameObject pinchos;
	public Animator pinchosAnimacion;
	public AnimationClip animacion;

	void Start(){
	}

	void Update(){

	}

	void OnTriggerEnter(Collider col){
		if (animacion.isLooping) {
		}
		if (col.tag == "Player") {
			pinchosAnimacion.SetTrigger ("Activado");
		}

	}
}
