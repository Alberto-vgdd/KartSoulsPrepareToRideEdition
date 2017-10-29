using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardTriggers : MonoBehaviour {


	public int triggerID;
    public GameObject hueso;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			
			GameObject nuevoHueso = Instantiate(hueso, new Vector3(other.transform.position.x, 
			other.transform.position.y + 20f,  other.transform.position.z), other.transform.rotation);
			nuevoHueso.SetActive(true);
			nuevoHueso.GetComponent<Rigidbody>().useGravity = true;
			Destroy(nuevoHueso, 4f);
		}
	}


}
