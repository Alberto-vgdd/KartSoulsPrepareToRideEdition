using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class TriggerBloomAndGrayscale : MonoBehaviour {

	public PostProcessingProfile m_PostProcessingProfile;
	public bool m_BloomEnabled = false;
	public bool m_GrayScaleEnabled = false;
	public Color m_CameraColor; 	

	// Use this for initialization
	void Start () {
		m_PostProcessingProfile.colorGrading.enabled = true;
		ColorGradingModel.Settings settings = m_PostProcessingProfile.colorGrading.settings;
		settings.basic.saturation = 1;
		m_PostProcessingProfile.colorGrading.settings = settings;
		 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void EnableGrayScale(){
		m_PostProcessingProfile.colorGrading.enabled = true;
		ColorGradingModel.Settings settings = m_PostProcessingProfile.colorGrading.settings;
		settings.basic.saturation = 0;
		m_PostProcessingProfile.colorGrading.settings = settings;
		RenderSettings.fogColor = Color.grey;
		Camera.main.backgroundColor = Color.grey;
	}

	void EnableBloom(){
		m_PostProcessingProfile.bloom.enabled = true;
	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player") {

			EnableGrayScale ();
			EnableBloom ();
		}
	}
}
