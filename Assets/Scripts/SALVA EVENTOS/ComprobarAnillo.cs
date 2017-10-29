using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarAnillo : MonoBehaviour {


	public GameObject anillo;

	// Update is called once per frame
	void Update () {
		if (anillo == null) {
			Destroy (this);
		}
	}
}
