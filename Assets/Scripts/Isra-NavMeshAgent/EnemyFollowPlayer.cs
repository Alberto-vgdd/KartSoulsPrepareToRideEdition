using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour {

	NavMeshAgent m_NavMeshAgent;
	Vector3 m_PlayerPosition;
	// Use this for initialization
	void Start () {
		m_PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		m_NavMeshAgent = GetComponent<NavMeshAgent>();
		m_NavMeshAgent.SetDestination(m_PlayerPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
