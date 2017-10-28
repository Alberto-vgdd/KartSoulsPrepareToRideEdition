using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour {

	NavMeshAgent m_NavMeshAgent;
	GameObject m_Player;
	Vector3 m_PlayerPosition;


	// Use this for initialization
	void Start () {
		m_Player = GameObject.Find("Player");
		m_NavMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

		if(m_Player.GetComponent<MensajesHUDJugador>().invadido){
			Debug.Log("a");
			m_PlayerPosition = m_Player.transform.position;
			transform.LookAt(m_PlayerPosition);
			m_NavMeshAgent.SetDestination(m_PlayerPosition);
			m_NavMeshAgent.Resume();
			if(Vector3.Distance(transform.position, m_PlayerPosition)< 2){
				m_Player.GetComponent<Rigidbody>().AddForce(transform.forward * 50000, ForceMode.Acceleration);
			}

		}
	}
}
