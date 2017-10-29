using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesTrigger : MonoBehaviour {


    public Rigidbody[] huesos = new Rigidbody[5];

	// Use this for initialization
	void Start () {

	}

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i>huesos.Length; i++) {

            huesos[i].useGravity = true;
        }
    }
}
