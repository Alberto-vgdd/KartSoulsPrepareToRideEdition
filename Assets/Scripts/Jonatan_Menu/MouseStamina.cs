using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseStamina : MonoBehaviour {

    public Button play;
    public Button exit;
    public float sensibility;
    public Slider slider;
    public GameObject mensaje;
    private float stamina = 100;
    bool recharge = false;


    Vector3 currentVelocity;
    
	// Use this for initialization
	void Start () {

        transform.position = Input.mousePosition;
        Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (!recharge)
        {
            Move();

            if (stamina <= 0)
            {
                recharge = true;
                mensaje.SetActive(true);
                BotonesState();
            }
            
        }
        else 
        {
            Recargar();
        }
		

        slider.value = stamina;
	}

    void Move() {

        transform.position = Vector3.SmoothDamp(transform.position,Input.mousePosition + new Vector3(0,-25,0), ref currentVelocity,0.05f ) ;

        if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
        {

            Recargar();
        }
        else
        {
            float calculo = Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))*5f;
            stamina -= calculo;
        }

    }

    void Recargar() {

        if (stamina < 100)
        {

            stamina +=  20f*Time.deltaTime;

        }
        else {

            stamina = 100;
            recharge = false;
            mensaje.SetActive(false);
            BotonesState();

        }
    }
    void BotonesState() {

        if (recharge)
        {

            play.enabled = false;
            exit.enabled = false;

        }
        else {

            play.enabled = true;
            exit.enabled = true;
          
        }

    }

    }
