using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoEsperaOrstein : MonoBehaviour {

	bool contarTiempo = false;
	public float tiempo = 20;
	public GameObject puertaAbrir, Orstein, Smough;
	private Transform posicionOrstein, posicionSmough;
	public CanvasValues canvas;

	public GameObject player;
	private PlayerMovementScript playerMovementScript;
	

	// Use this for initialization
	void Awake () {
		playerMovementScript = player.GetComponent<PlayerMovementScript>();
		posicionOrstein = Orstein.transform;
		posicionSmough = Smough.transform;
		Smough.SetActive (false);
		Orstein.SetActive (false);
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Player") {
			contarTiempo = true;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			contarTiempo = false;
			tiempo = 20;
			puertaAbrir.SetActive (true);
			Orstein.transform.position = posicionOrstein.position;
			Smough.transform.position = posicionSmough.position;
			Orstein.SetActive (true);
			Smough.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") 
		{
			Orstein.SetActive (false);
			Smough.SetActive (false);
			Orstein.GetComponent<OrnsteinBehaviour>().setOrPos();
			Smough.GetComponent<SmoughBehaviour>().setOrPos();
			contarTiempo = false;
			tiempo = 20;
			canvas.SetHumanityCountText (20);
		}

	}

	// Update is called once per frame
	void Update () 
	{
		if (playerMovementScript.isPlayerDead())
		{
			contarTiempo = false;
			tiempo = 20;
			canvas.SetHumanityCountText (20);
		}

		if (contarTiempo) {
			tiempo -= Time.deltaTime;
			canvas.SetHumanityCountText ((int) tiempo);
		}

		if (tiempo <= 0) {
			canvas.SetHumanityCountText (0);
			puertaAbrir.SetActive (false);
		}
	}
}
