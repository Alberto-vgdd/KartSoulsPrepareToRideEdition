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
		coolDownTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//this.transform.LookAt(player.transform.position);
		coolDownTime += Time.deltaTime;

		if (coolDownTime > 3.0f && (player.transform.position-myself.transform.position).magnitude > 5f)
		{
			UnderMyUmbrellaEhEhEh();
			coolDownTime = 0.0f;
		}
		
	}

	void UnderMyUmbrellaEhEhEh()
	{
		GameObject projectile = Instantiate(Umbrella,
		new Vector3( shootingPosition.transform.position.x,shootingPosition.transform.position.y, 
		shootingPosition.transform.position.z ), 
		Quaternion.LookRotation(shootingPosition.transform.position - player.transform.position 
								+ new Vector3(0f, -1.5f, 0f)));
		projectile.transform.position = new Vector3(shootingPosition.transform.position.x  - 1.5f, 
				shootingPosition.transform.position.y, 	shootingPosition.transform.position.z);
		projectile.SetActive(true);
		projectile.GetComponent<Rigidbody>().AddForce(-projectile.transform.forward * rainingForce,
													  ForceMode.VelocityChange);
		Destroy(projectile, 3f);
	}

	


}
