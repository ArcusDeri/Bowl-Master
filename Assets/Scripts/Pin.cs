using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float StandingThreshold;

	void Start(){
		StandingThreshold = transform.rotation.eulerAngles.y;
	}

	public bool IsStanding(){
		Vector3 eulerRotation = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(eulerRotation.x);
		float tiltInZ = Mathf.Abs(eulerRotation.z);
		
		return tiltInX < StandingThreshold && tiltInZ < StandingThreshold;
	}
}
