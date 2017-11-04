using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {


    private bool alreadyPressed;

    [Range(100, 1000)]
    public float offsetXPlayButton = 500f;

    public GameObject PlayButton;

	// Use this for initialization
	void Start () 
	{
		this.GetComponent<Animation>().Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	public void StartGame()
	{
        if (!alreadyPressed)
        {
            PlayButton.GetComponent<RectTransform>().position = new Vector3( PlayButton.GetComponent<RectTransform>().position.x -offsetXPlayButton,
                       PlayButton.GetComponent<RectTransform>().position.y, PlayButton.GetComponent<RectTransform>().position.z);
            alreadyPressed = true;
        }
        else
        {
            SceneManager.LoadScene("Salva-EscenarioPrincipal");
        }
		
	}

	public void QuitGame()
	{
		Application.Quit();
	}


}
