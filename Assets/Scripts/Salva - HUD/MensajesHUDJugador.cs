﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajesHUDJugador : MonoBehaviour {

	CanvasValues canvasController;
	private float tiempoFalloInvocar;
	private bool contarFallo;
	private bool envenenando;
	public bool invadido;

	public CheckpointSystem checkpointSystem;

	// Use this for initialization
	void Start () {
		canvasController = GameObject.Find ("HUD Canvas").GetComponent<CanvasValues> ();
		tiempoFalloInvocar = 0;
		contarFallo = false;
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Veneno") {
			envenenando = false;
			GetComponent<PlayerMovementScript> ().SetDefaultSpeed();
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Estus") {
			canvasController.ShowDialogText ("You have obtained the Estus Flask");
			col.gameObject.SetActive (false);
		}

		if (col.tag == "Muerte") {
			canvasController.ShowTitleText ("YOU DIED", Color.red);
		}

		if (col.tag == "Bolardo") {
			gameObject.GetComponent<PlayerMovementScript>().ApplyLife(-1000f);
			gameObject.GetComponent<PlayerMovementScript>().enabled = false;
			gameObject.GetComponent<CapsuleCollider>().enabled = false;
			gameObject.GetComponent<Rigidbody>().isKinematic = true;
			transform.localScale = new Vector3(1,0.01f,1);
			canvasController.ShowTitleText ("YOU DIED", Color.red);
			Destroy(col.gameObject,2f);
			Invoke("SendPlayerToLastCheckpoint",2f);
		}

		if (col.tag == "RecuperarAlmas") {
			canvasController.ShowTitleText ("SOULS RETRIEVED", Color.green);
			canvasController.SetSoulCountText (canvasController.GetSoulTextCount() + 200);
			col.gameObject.SetActive (false);
		}

		if (col.tag == "Checkpoint") {
			Application.targetFrameRate = 0;
			canvasController.ShowTitleText ("BONFIRE LIT", Color.yellow);
			checkpointSystem.SetLastCheckpoint(col.transform);
			gameObject.GetComponent<PlayerMovementScript>().ApplyLife(1000f);
			gameObject.GetComponent<PlayerMovementScript>().ApplyStamina(1000f);
			col.enabled = false;
		}

		if (col.tag == "Campana1") {
			canvasController.ShowDialogText ("Gargoyle Bell activated");
		}

		if (col.tag == "Campana2") {
			canvasController.ShowDialogText ("Quelaag Bell activated");
		}

		if (col.tag == "Invocacion") {
			canvasController.ShowDialogText ("Summoning x_MinecraftSexMaster_x phantom");
			contarFallo = true;
		}

		if (col.tag == "Texto1") {
			canvasController.ShowDialogText ("Run.");
			contarFallo = false;
		}

		if (col.tag == "Texto2") {
			canvasController.ShowDialogText ("Amazing Texture ahead");
			contarFallo = false;
		}

		if(col.tag == "Invasion"){
			invadido = true;
		}

		if(col.tag == "Zona"){
			canvasController.ShowZoneName (col.name);
		}

		if (col.tag == "Veneno") {
			GetComponent<PlayerMovementScript> ().SetSpeed (5f);
		}

	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Veneno" && canvasController.m_IsPoisoned == false) {
			canvasController.SetPoisonValue (canvasController.GetPoisonValue () + 0.2f);
			envenenando = true;
			GetComponent<PlayerMovementScript> ().SetSpeed (5f);
		}
	}
	// Update is called once per frame
	void Update () {
		if (contarFallo == true) {
			tiempoFalloInvocar += Time.deltaTime;
			if (tiempoFalloInvocar >= 5) {
				canvasController.ShowDialogText ("Unable to summon x_MinecraftSexMaster_x phantom");
			}
			if (tiempoFalloInvocar >= 10) {
				contarFallo = false;
				tiempoFalloInvocar = 0;
			}
		}

		if (envenenando == false && canvasController.m_IsPoisoned == false) {
			canvasController.SetPoisonValue (canvasController.GetPoisonValue () - 0.2f);
		}

		if (canvasController.m_IsPoisoned == true) {
			GetComponent<PlayerMovementScript> ().ApplyLife(-5f*Time.deltaTime);
			canvasController.SetPoisonValue (canvasController.GetPoisonValue () - 0.05f);
		}
	}



	void SendPlayerToLastCheckpoint()
	{
		gameObject.GetComponent<PlayerMovementScript>().ApplyLife(+1000f);
		gameObject.GetComponent<PlayerMovementScript>().ApplyStamina(1000f);
		gameObject.GetComponent<PlayerMovementScript>().enabled = true;
		gameObject.GetComponent<CapsuleCollider>().enabled = true;
		gameObject.GetComponent<Rigidbody>().isKinematic = false;
		transform.localScale = new Vector3(1,1f,1);
		checkpointSystem.SendPlayerToLastCheckpoint();
	}
}
