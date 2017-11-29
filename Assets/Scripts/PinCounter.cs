using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text StandingDisplay;
	
	private GameManager MyGameManager;
	private bool IsBallOutOfPlay = false;
	private float LastChangeTime;
	private int LastSettledCount = 10;
	private int LastStandingCount = -1;

	// Use this for initialization
	void Start () {
		MyGameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		StandingDisplay.text = CountStanding().ToString();
		if(IsBallOutOfPlay){
			UpdateStandingCountAndSettle();
			StandingDisplay.color = Color.red;
		}
	}
	void UpdateStandingCountAndSettle(){
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
		int standing = CountStanding();
		int pinFall = LastSettledCount - standing;
		LastSettledCount = standing;
		MyGameManager.Bowl(pinFall);
		
		LastStandingCount = -1; //means that pins have settled and ball not back in box
		IsBallOutOfPlay = false;
		StandingDisplay.color = Color.green;
	}

	public int CountStanding(){
		int counter = 0;
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			counter += pin.IsStanding() ? 1 : 0;
		}
		return counter;
	} 

	public void Reset(){
		LastSettledCount = 10;
	}

	void OnTriggerExit(Collider collider){
		if(collider.gameObject.name == "Ball"){
			IsBallOutOfPlay = true;
		}
	}
}
