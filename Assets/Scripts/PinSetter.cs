using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public Text StandingDisplay;

	private bool BallInBox = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StandingDisplay.text = CountStanding().ToString();
	}

	public int CountStanding(){
		int counter = 0;
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			counter += pin.IsStanding() ? 1 : 0;
		}
		return counter;
	}

	void OnTriggerEnter(Collider collider){
		var objectHit = collider.gameObject;
		if(objectHit.GetComponent<Ball>()){
			BallInBox = true;
			StandingDisplay.color = Color.red;
		}
	}
	void OnTriggerExit(Collider collider){
		var objectLeft = collider.gameObject;
		if(objectLeft.GetComponent<Pin>()){
			Destroy(objectLeft);
		}
	}
}
