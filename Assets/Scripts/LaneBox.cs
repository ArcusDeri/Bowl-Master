using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {

	private PinSetter MyPinSetter;

	// Use this for initialization
	void Start () {
		MyPinSetter = GameObject.FindObjectOfType<PinSetter>();
	}
	
	void OnTriggerExit(Collider collider){
		if(collider.gameObject.name == "Ball"){
			MyPinSetter.BallLeftTheBox = true;
		}
	}
}
