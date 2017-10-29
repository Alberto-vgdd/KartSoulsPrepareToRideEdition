using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elcenizo : MonoBehaviour
 {
	public PlayerMovementScript playerMovement;
	public GameObject cenizo;
	public CanvasValues hud;


	float timer = 30f;
	float minTime = 0f;
	bool playerInside;

	
	// Update is called once per frame
	void Update () 
	{
		if (playerInside)
		{
			timer -= Time.deltaTime;
			timer = Mathf.Clamp(timer,0f,30f);
			hud.SetHumanityCountText((int)timer);

			if (playerMovement.isPlayerDead())
			{
				cenizo.SetActive(false);
				playerInside = false;
				hud.SetHumanityCountText((int)30);
			}

			if ( timer <= minTime)
			{
				cenizo.SetActive(false);
				hud.ShowTitleText("HORNY HORNO", Color.green);
				playerMovement.enabled = false;
				Invoke("Fin", 3f);
			}
		}
		
	}


	void OnTriggerEnter(Collider othen)
	{
		if (othen.gameObject.tag == "Player")
		{
			playerInside = true;
			timer = 30f;
			cenizo.SetActive(true);
			hud.SetHumanityCountText((int)timer);
		}
	}

	void Fin()
	{
		SceneManager.LoadScene(0);
	}
}
