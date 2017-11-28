using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float StandingThreshold = 3f;

	private Rigidbody MyRigidbody;

	void Start(){
		MyRigidbody = GetComponent<Rigidbody>();
	}

	public bool IsStanding(){
		Vector3 eulerRotation = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(270 - eulerRotation.x);
		float tiltInZ = Mathf.Abs(eulerRotation.z);
		//it has to be like that cause eulerAngles are too precise surprisingly
		if((tiltInX < StandingThreshold || tiltInX > 357) && (tiltInZ < StandingThreshold || tiltInZ > 357))
			return true;
		else
			return false;
	}

	public void RaiseIfStanding(float distance){
		if(IsStanding()){
			MyRigidbody.useGravity = false;
			transform.Translate(new Vector3(0,distance,0),Space.World);
			transform.rotation = Quaternion.Euler(270f,0,0);
		}
	}

	public void Lower(float distance){
		transform.Translate(new Vector3(0,distance,0),Space.World);
		MyRigidbody.useGravity = true;
	}
}
