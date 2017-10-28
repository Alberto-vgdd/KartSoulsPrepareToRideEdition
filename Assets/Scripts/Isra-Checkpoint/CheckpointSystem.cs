using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour {

	public Transform m_LastCheckPoint;
	public Vector3 m_PlayerStartingPosition;
	public GameObject m_Player;
	
	void Start () {
		m_Player = GameObject.FindGameObjectWithTag("Player");
		m_PlayerStartingPosition = m_Player.transform.position;
	}
	
	public void SendPlayerToLastCheckpoint(){
		if(m_LastCheckPoint != null)
			m_Player.transform.position = m_LastCheckPoint.position;
		else
			m_Player.transform.position = m_PlayerStartingPosition;
	}

	public void SetLastCheckpoint(Transform Checkpoint){
		m_LastCheckPoint = Checkpoint;
	}
	
}
