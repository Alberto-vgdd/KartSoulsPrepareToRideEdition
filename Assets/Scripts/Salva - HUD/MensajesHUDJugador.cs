using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajesHUDJugador : MonoBehaviour {

	CanvasValues canvasController;
	private float tiempoFalloInvocar;
	private bool contarFallo;

	// Use this for initialization
	void Start () {
		canvasController = GameObject.Find ("HUD Canvas").GetComponent<CanvasValues> ();
		tiempoFalloInvocar = 0;
		contarFallo = false;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Estus") {
			canvasController.ShowDialogText ("You have obtained the Estus Flask");
			col.gameObject.SetActive (false);
		}

		if (col.tag == "Muerte") {
			canvasController.ShowTitleText ("YOU DIED", Color.red);
		}

		if (col.tag == "RecuperarAlmas") {
			canvasController.ShowTitleText ("SOULS RETRIEVED", Color.green);
			canvasController.SetSoulCountText (canvasController.GetSoulTextCount() + 200);
			col.gameObject.SetActive (false);
		}

		if (col.tag == "Checkpoint") {
			canvasController.ShowDialogText ("Bonfire Lit");
		}

		if (col.tag == "Invocacion") {
			canvasController.ShowDialogText ("Summoning x_MinecraftSexMaster_x phantom");
			contarFallo = true;
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
		
	}
}
