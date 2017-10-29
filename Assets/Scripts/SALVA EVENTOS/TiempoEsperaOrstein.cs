using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoEsperaOrstein : MonoBehaviour {

	bool contarTiempo = false;
	public float tiempo = 0;
	public GameObject puertaAbrir;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Player") {
			contarTiempo = true;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			contarTiempo = false;
			tiempo = 0;
			puertaAbrir.SetActive (true);
		}

	}

	// Update is called once per frame
	void Update () {
		if (contarTiempo) {
			tiempo += Time.deltaTime;
		}

		if (tiempo >= 20) {
			puertaAbrir.SetActive (false);
		}
	}
}
