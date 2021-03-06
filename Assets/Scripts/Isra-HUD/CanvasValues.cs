﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasValues : MonoBehaviour {

	public Text m_HumanityCountText;
	public Slider m_LifeBarSlider;
	public Slider m_StaminaBarSlider;
	public Text m_SoulCountText;

	public Text m_DialogText;
	public Animation m_TextDialogAnimation; 

	public Text m_TitleText;
	public Animation m_TitleTextAnimation; 

	public Text m_PoisonedText;
	public Slider m_PoisonSlider;
	public Image m_PoisonFillImage;
	Color m_PoisonDefaultColor;
	public Image m_PoisonIndicatorImage;

	public Text m_ZoneNameText;
	public Animation m_ZoneNameAnimation;

	public Image m_BlackImage;

	bool fill;

	public bool m_IsPoisoned;




	[Header("Player Variables")]
	public PlayerMovementScript playerMovementScript;
	public Rigidbody playerRigidbody;
	public CapsuleCollider playerCollider;
	public Transform playerTransform;

	[Header("CheckPoint Manager")]
	public CheckpointSystem checkpointSystem;
	

	void Start(){
		m_IsPoisoned = false;
		m_PoisonedText.gameObject.SetActive(false);
		m_PoisonDefaultColor = m_PoisonFillImage.color;
	}

	public void SetHumanityCountText(int humanityCount){
		m_HumanityCountText.text = humanityCount.ToString();
	}	

	public int GetHumanityTextCount(){
		return int.Parse(m_HumanityCountText.text);
	}


	public void SetMaxLifebarValue(int maxValue){
		m_LifeBarSlider.maxValue = maxValue;
	}

	public void SetLifebarValue(int value){
		m_LifeBarSlider.value = value;

		if (value == 0 && playerMovementScript.enabled)
		{
			playerMovementScript.enabled = false;
			playerCollider.enabled = false;
			playerRigidbody.isKinematic = true;
			ShowTitleText ("YOU DIED", Color.red);
			Invoke("SendPlayerToLastCheckpoint",2f);
		}
	}

	public int GetLifebarMaxValue(){
		return (int) m_LifeBarSlider.maxValue;
	}

	public int GetLifebarValue(){
		return (int) m_LifeBarSlider.value;
	}

	public void SetMaxStaminaBarValue(int maxValue){
		m_StaminaBarSlider.maxValue = maxValue;
	}

	public void SetStaminaBarValue(int value){
		m_StaminaBarSlider.value = value;
	}

	public int GetStaminaBarMaxValue(){
		return (int) m_StaminaBarSlider.maxValue;
	}

	public int GetStaminaBarValue(){
		return (int) m_StaminaBarSlider.value;
	}

	public void SetSoulCountText(int soulCount){
		m_SoulCountText.text = soulCount.ToString();
	}	

	public int GetSoulTextCount(){
		return int.Parse(m_SoulCountText.text);
	}

	public void ShowDialogText(string message){
		m_DialogText.text = message;
		m_TextDialogAnimation.Play();
	}

	public void ShowTitleText(string message, Color color){
		m_TitleText.text = message;
		m_TitleText.color = color;
		m_TitleTextAnimation.Play();
		if(color == Color.red){
			FadeIn();
			Invoke("FadeOut", 3f);
		}
	}

	public void SetPoisonValue(float value){
		m_PoisonSlider.value = value;
		if(m_PoisonSlider.value >= 1){
			m_PoisonIndicatorImage.gameObject.SetActive(true);
		}
		if(m_PoisonSlider.value == m_PoisonSlider.maxValue){
			m_PoisonFillImage.color = m_PoisonSlider.colors.normalColor;
			m_PoisonedText.gameObject.SetActive(true);
			m_IsPoisoned = true;
		}else if(m_PoisonSlider.value == 0){
			m_PoisonFillImage.color = m_PoisonDefaultColor;
			m_PoisonedText.gameObject.SetActive(false);
			m_PoisonIndicatorImage.gameObject.SetActive(false);
			m_IsPoisoned = false;
		}
	}

	public float GetPoisonValue(){
		return m_PoisonSlider.value;
	}

	public void ShowZoneName(string name){
		m_ZoneNameText.text = name;
		m_ZoneNameAnimation.Play();
	}


	public void FadeOut(){
		m_BlackImage.GetComponent<Animation>().Play();
	}

	public void FadeIn(){
		m_BlackImage.GetComponent<Animation>().Play("Fade In BLACK");
	}

	void Update(){
		/*
		if(fill){
			SetPoisonValue(m_PoisonSlider.value + 0.5f);
			if(m_PoisonSlider.value == m_PoisonSlider.maxValue){
				fill = false;
			}
		}else{
			SetPoisonValue(m_PoisonSlider.value - 0.5f);

		}

		*/
		
	}


	void SendPlayerToLastCheckpoint()
	{
		playerMovementScript.enabled = true;
		playerMovementScript.ApplyLife(+1000f);
		playerMovementScript.ApplyStamina(1000f);
		SetPoisonValue(0f);
		playerMovementScript.SetDefaultSpeed();
		
		playerCollider.enabled = true;
		playerRigidbody.isKinematic = false;
		playerTransform.localScale = new Vector3(1,1f,1);

		checkpointSystem.SendPlayerToLastCheckpoint();
	}

}

