using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> Rolls = new List<int>();
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
			Rolls.Add(pinFall);
			MyBall.Reset();
			ActionMaster.Action nextAction = ActionMaster.NextAction(Rolls);
			MyPinSetter.PerformAction(nextAction);
		}
		catch{
			Debug.LogWarning("Something went wrong in Bowl()");
		}
		try{
			ScoreDisplay.FillRolls(Rolls);
			ScoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(Rolls));
		}
		catch{
			Debug.LogWarning("ScoreDisplay failed.");
		}
	}
}
