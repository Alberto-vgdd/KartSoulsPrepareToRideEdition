using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseStamina : MonoBehaviour {

    public float sensibility;
    public Slider slider;
    public GameObject mensaje;
    private float stamina = 200;
    bool recharge = false;
	// Use this for initialization
	void Start () {

        transform.position = Input.mousePosition;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {

        slider.value = stamina;
        Move();
        if (!recharge) { EstaminaCalculo();

            mensaje.SetActive(false);
        }
        else { Recargar();
            mensaje.SetActive(true);
        }
		
	}

    void Move() {

        if (!recharge) { transform.Translate(Input.GetAxis("Mouse X") * sensibility, Input.GetAxis("Mouse Y")* sensibility,0); }
        if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) {

            Recargar();
        }

    }

    void EstaminaCalculo()
    {
        if (stamina <= 0)
        {

            recharge = true;
            
        }
        else {

            float calculo = (Mathf.Abs(Input.GetAxis("Mouse X") + Mathf.Abs(Input.GetAxis("Mouse Y"))))*5;
            print(calculo);
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
      
        }
    }

}
