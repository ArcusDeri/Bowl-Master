using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> Bowls = new List<int>();
	private PinSetter MyPinSetter;
	private Ball MyBall;
	private Scores ScoreDisplay;

	// Use this for initialization
	void Start () {
		MyBall = GameObject.FindObjectOfType<Ball> ();
		MyPinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ScoreDisplay = GameObject.FindObjectOfType<Scores>();
	}
	
	public void Bowl(int pinFall){
		try{
			Bowls.Add(pinFall);
			MyBall.Reset();
			ActionMasterOld.Action nextAction = ActionMasterOld.NextAction(Bowls);
			MyPinSetter.PerformAction(nextAction);
		}
		catch{
			Debug.LogWarning("Something went wrong in Bowl()");
		}
		try{
			ScoreDisplay.FillRollCard(Bowls);	
		}
		catch{
			Debug.LogWarning("ScoreDisplay failed.");
		}
	}
}
