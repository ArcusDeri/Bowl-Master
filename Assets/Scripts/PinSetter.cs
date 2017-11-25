using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public Text StandingDisplay;
	public int LastStandingCount = -1;
	public float DistanceToRaise = 40f;
	public GameObject PinSet;

	private Ball MyBall;
	private bool BallInBox = false;
	private float LastChangeTime;
	private int LastSettledCount = 10;
	private ActionMaster MyActionMaster;
	private Animator MyAnimator;

	// Use this for initialization
	void Start () {
		MyBall = GameObject.FindObjectOfType<Ball>();
		MyActionMaster = new ActionMaster();
		MyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		StandingDisplay.text = CountStanding().ToString();
		if(BallInBox){
			UpdateStandingCountAndSettle();
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
		StandingDisplay.color = Color.green;
		ResetBall();
		TriggerSwiperAction(pinFall);
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
		LastSettledCount = 10;
		GameObject newPins = Instantiate(PinSet);
		newPins.transform.position += new Vector3(0,30,0);
	}

	private void TriggerSwiperAction(int pinFall){
	var result = MyActionMaster.Bowl(pinFall);
		switch(result){
			case ActionMaster.Action.Tidy:
				MyAnimator.SetTrigger("TidyTrigger");
				break;
			case ActionMaster.Action.Reset:
				MyAnimator.SetTrigger("ResetTrigger");
				break;
			case ActionMaster.Action.EndTurn:
				MyAnimator.SetTrigger("ResetTrigger");
				break;
			default:
				throw new UnityException("Can't handle this action: " + result + ".");
		}	
	}
	private void ResetBall(){
		MyBall.Reset();
		LastStandingCount = -1; //indicates pins are settled and ball not back in box
		BallInBox = false;
	}
}
