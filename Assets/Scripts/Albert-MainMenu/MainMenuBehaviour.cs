﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {


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
		//SceneManager.LoadScene("");
	}

	public void QuitGame()
	{
		Application.Quit();
	}


}
