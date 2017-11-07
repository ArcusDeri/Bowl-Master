using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Ball MyBall;

	private Vector3 Offset;

	// Use this for initialization
	void Start () {
		Offset = gameObject.transform.position - MyBall.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		FollowTheBallToPin ();
	}

	void FollowTheBallToPin ()
	{
		if(MyBall.transform.position.z < 1800)
			gameObject.transform.position = MyBall.transform.position + Offset;		
	}
}
