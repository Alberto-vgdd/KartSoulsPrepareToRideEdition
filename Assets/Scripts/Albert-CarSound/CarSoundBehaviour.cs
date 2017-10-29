using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundBehaviour : MonoBehaviour {

	//Los valores deseados para el pitch es entre 0.7f y 1.2f
	public AudioClip carEngine;
	[Range(0.0f,1.0f)]
	public float carEngineModifier;

	public AudioSource playerEmitter;

	// Use this for initialization
	void Start () {
		playerEmitter.clip = carEngine;
		playerEmitter.volume = 0.4f;
		playerEmitter.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		carEngineSoundModifier();	
	}

	void carEngineSoundModifier()
	{
		playerEmitter.pitch = Mathf.Clamp((carEngineModifier / 2f) + 0.7f, 0.7f, 1.2f);

	}



}
