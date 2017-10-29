using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesTrigger : MonoBehaviour {


    public GameObject[] huesos = new GameObject[5];
    public Transform player;
    private float timer;

	// Use this for initialization
	void Start () {

	}

    private void Update()
    {

        transform.position = new Vector3(player.position.x, player.position.y + 10, player.position.z);
        if (timer < 5)
        {

            timer += Time.deltaTime;

        }
        else {

            timer = 0;
            for (int i = 0; i < huesos.Length; i++) {

                GameObject hueso =  Instantiate(huesos[i].gameObject, huesos[i].transform);
                hueso.GetComponent<Rigidbody>().useGravity = true;
                Destroy(hueso, 5f);
            }
            
        }
        
    }
}
