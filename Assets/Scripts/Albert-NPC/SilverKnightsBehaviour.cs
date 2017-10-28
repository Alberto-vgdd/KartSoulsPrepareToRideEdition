using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverKnightsBehaviour : MonoBehaviour {

	public GameObject Umbrella;
	public GameObject myself;
	public GameObject player;
	public GameObject shootingPosition;
	[Range(10,100)]
	public float rainingForce;

	private float coolDownTime;

	// Use this for initialization
	void Start () 
	{
		myself = this.gameObject;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			UnderMyUmbrellaEhEhEh();
		}
		
	}

	void UnderMyUmbrellaEhEhEh()
	{
		GameObject projectile = Instantiate(Umbrella,
		new Vector3( shootingPosition.transform.position.x,shootingPosition.transform.position.y, 
		shootingPosition.transform.position.z - 1.5f), 
		Quaternion.LookRotation(shootingPosition.transform.position - player.transform.position));
		projectile.SetActive(true);
		projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.right*rainingForce, ForceMode.VelocityChange);
	}

	


}
