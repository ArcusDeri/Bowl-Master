using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public Text StandingDisplay;
	public int LastStandingCount = -1;
	public float DistanceToRaise = 40f;

	private Ball MyBall;
	private bool BallInBox = false;
	private float LastChangeTime;
	// Use this for initialization
	void Start () {
		MyBall = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		StandingDisplay.text = CountStanding().ToString();
		if(BallInBox){
			CheckStanding();
		}
	}

	void CheckStanding(){
		int currentStanding = CountStanding();
		if(currentStanding != LastStandingCount){
			LastChangeTime = Time.time;
			LastStandingCount = currentStanding;
			return;
		}
		float settleTime = 3f;//how long wait to consider pins settled
		if((Time.time - LastChangeTime) > settleTime){
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled(){
		MyBall.Reset();
		LastStandingCount = -1; //indicates pins are settled and ball not back in box
		BallInBox = false;
		StandingDisplay.color = Color.green;
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

	public void RaisePins(){
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding(DistanceToRaise);
		}
	}

	public void LowerPins(){
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower(-DistanceToRaise);
		}
	}

	public void RenewPins(){
		Debug.Log("renewin");
	}
}
