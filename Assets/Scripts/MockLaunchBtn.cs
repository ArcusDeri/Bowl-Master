using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockLaunchBtn : MonoBehaviour {
	public Vector3 Velocity = new Vector3(0,0,400);

	public void MockLaunch(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		ball.Launch(Velocity);
	}
}
