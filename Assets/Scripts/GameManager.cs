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
		Bowls.Add(pinFall);
		MyBall.Reset();
		ActionMaster.Action nextAction = ActionMaster.NextAction(Bowls);
		MyPinSetter.PerformAction(nextAction);
		ScoreDisplay.FillRollCard(Bowls);		
	}
}
