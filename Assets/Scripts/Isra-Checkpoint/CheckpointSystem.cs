using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem: MonoBehaviour
{
	public  Transform m_LastCheckPoint;
	public  GameObject m_Player;
	
	public void SendPlayerToLastCheckpoint()
	{
		if(m_LastCheckPoint != null)
			m_Player.transform.position = m_LastCheckPoint.position;
	}

	public void SetLastCheckpoint(Transform Checkpoint)
	{
		m_LastCheckPoint = Checkpoint;
	}
	
}
