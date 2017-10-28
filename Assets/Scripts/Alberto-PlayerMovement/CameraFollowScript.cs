using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour 
{


	[Header("Camera Parameters")]
	public Transform playerCameraTarget;
	public Transform playerPivotTransform;
	public float cameraFollowTime;
	public float cameraRotationTime;

	private Transform cameraPivot;

	// Variables to follow the player
	private Vector3 currentCameraFollowVelocity;
	private float currentCameraRotationVelocity;

	// Use this for initialization
	void Awake () 
	{
		cameraPivot = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		cameraPivot.position = Vector3.SmoothDamp(cameraPivot.position, playerCameraTarget.position, ref currentCameraFollowVelocity, cameraFollowTime);
		cameraPivot.rotation = Quaternion.Euler(0f,Mathf.SmoothDampAngle(cameraPivot.eulerAngles.y,playerPivotTransform.eulerAngles.y, ref currentCameraRotationVelocity,cameraRotationTime),0f);
	}
}
