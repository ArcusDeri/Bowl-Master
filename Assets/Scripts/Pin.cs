using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float StandingThreshold = 3f;

	void Start(){
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
}
