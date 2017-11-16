using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {
	private Ball MyBall;
	private float StartTime;
	private float EndTime;
	private Vector3 StartPos;
	private Vector3 EndPos;
	// Use this for initialization
	void Start () {
		MyBall = GetComponent<Ball>();
	}

	public void DragStart(){
		StartTime = Time.time;
		StartPos = Input.mousePosition;
	}

	public void DragStop(){
		EndTime = Time.time;
		float dragDuration = EndTime - StartTime;
		EndPos = Input.mousePosition;
		Vector3 dragVector = EndPos - StartPos;

		float speedX = dragVector.x/ dragDuration;
		float speedZ = dragVector.y/ dragDuration;

		MyBall.Launch(new Vector3(speedX,0,speedZ));
	}
}
