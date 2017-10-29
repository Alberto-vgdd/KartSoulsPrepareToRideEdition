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
    private float stamina = 200;
    bool recharge = false;
    
	// Use this for initialization
	void Start () {

        transform.position = Input.mousePosition;
        //Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        
        slider.value = stamina;
        Move();
        if (!recharge) { EstaminaCalculo();

            mensaje.SetActive(false);
        }
        else {
            mensaje.SetActive(true);
            if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
            {

                Recargar();
            }
        }
		
	}

    void Move() {

        transform.position = Input.mousePosition + new Vector3(0,-25,0); 
        if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) {

            Recargar();
        }

    }

    void EstaminaCalculo()
    {
        if (stamina <= 0)
        {

            recharge = true;
            BotonesState();

        }
        else {

            float calculo = (Mathf.Abs(Input.GetAxis("Mouse X") + Mathf.Abs(Input.GetAxis("Mouse Y"))))*15f;
            stamina = stamina - calculo ;

        }


    }

    void Recargar() {

        if (stamina < 200)
        {

            stamina = stamina + 1;

        }
        else {

            stamina = 200;
            recharge = false;
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
