using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GwinBehaviour : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovementScript>().ApplyLife(-20);
            other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000f,
                                                                 ForceMode.VelocityChange);
            
        }
    }
}
