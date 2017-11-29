using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> Bowls = new List<int>();
	private PinSetter MyPinSetter;
	private Ball MyBall;

	// Use this for initialization
	void Start () {
		MyBall = GameObject.FindObjectOfType<Ball> ();
		MyPinSetter = GameObject.FindObjectOfType<PinSetter> ();
	}
	
	public void Bowl(int pinFall){
		Bowls.Add(pinFall);
		ActionMaster.Action nextAction = ActionMaster.NextAction(Bowls);
		MyPinSetter.PerformAction(nextAction);
		MyBall.Reset();
	}
}
