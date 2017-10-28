using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeonzaMovement : MonoBehaviour {

    public float peonzaRotationSpeed;
    public float step;
    public GameObject player;
    private float MoveX;
    private float MoveY;
    public Transform[] pilares = new Transform[8];
    public int pos;


    private void Awake()
    {
        int pos = Random.Range(0, 7);
    }

    // Update is called once per frame
    void Update () {


        CalculateRebote();
        Move();
		
	}


    void Move() {

        player.transform.Rotate(0,peonzaRotationSpeed,0);
        transform.position = Vector3.MoveTowards(transform.position, pilares[pos].position, step);


    }

    void CalculateRebote() {
        if (transform.position == pilares[pos].position) {

            pos = Random.Range(pos + 2, pos+6);
            if (pos > 7) {
                pos = pos - 8;
            }
        }


    }
}
