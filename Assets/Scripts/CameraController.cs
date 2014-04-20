using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Vector3 bufferXStart, bufferXEnd;
	Vector3 initialTarget;
	Vector3 destination;
	Vector3 velocity = Vector3.zero;
	float smoothTime = .15f;
	Transform target;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.Find ("RobotDefault").transform;						// Finds the transform of the robot
		transform.position = target.position + new Vector3 (7.2f, 2.8f, -10);		// Positions the camera on the robot plus some offset
		initialTarget = target.position + new Vector3 (7.2f, 2.8f, -10);
		bufferXStart = target.position + new Vector3 (10, 1, 0);				 	// Sets the position of the x-direction start buffer
		bufferXEnd = target.position + new Vector3 (25, 1, 0);						// Sets the position of the x-direction end buffer						
	}
	
	// Update is called once per frame
	void Update ()
	{
		target = GameObject.Find ("RobotDefault").transform;						// Finds the transform of the robot

		// If the robot stays within the x-direction buffer, the camera follows the player
		if (target.position.x >= bufferXStart.x && target.position.x <= bufferXEnd.x)		
		{
			destination = target.position + new Vector3 (0, 2.8f, -10);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothTime); 
		}
		else if (target.position.x <= bufferXStart.x)
		{
			transform.position = Vector3.SmoothDamp(transform.position, initialTarget, ref velocity, smoothTime);
		}
	}
}
