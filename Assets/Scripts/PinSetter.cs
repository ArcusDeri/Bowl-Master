using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public float DistanceToRaise = 40f;
	public GameObject PinSet;

	private ActionMasterOld MyActionMaster;
	private Animator MyAnimator;
	private PinCounter MyPinCounter;

	// Use this for initialization
	void Start () {
		MyPinCounter = GameObject.FindObjectOfType<PinCounter>();
		MyActionMaster = new ActionMasterOld();
		MyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

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
		MyPinCounter.Reset();
		GameObject newPins = Instantiate(PinSet);
		newPins.transform.position += new Vector3(0,30,0);
	}

	public void PerformAction(ActionMasterOld.Action action){
		switch(action){
			case ActionMasterOld.Action.Tidy:
				MyAnimator.SetTrigger("TidyTrigger");
				break;
			case ActionMasterOld.Action.Reset:
				MyAnimator.SetTrigger("ResetTrigger");
				MyPinCounter.Reset();
				break;
			case ActionMasterOld.Action.EndTurn:
				MyAnimator.SetTrigger("ResetTrigger");
				MyPinCounter.Reset();
				break;
			default:
				throw new UnityException("Can't handle this action: " + action + ".");
		}	
	}
}
