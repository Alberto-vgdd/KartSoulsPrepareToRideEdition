using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasValues : MonoBehaviour {

	public Text m_HumanityCountText;
	public Slider m_LifeBarSlider;
	public Slider m_StaminaBarSlider;
	public Text m_SoulCountText;

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

}

