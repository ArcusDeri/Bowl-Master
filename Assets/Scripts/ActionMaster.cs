using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame}
	
	private int BowlNumber = 1;
	private bool IsBowl21stAwarded = false;
	private int[] Bowls = new int [21];

	public static Action NextAction(List<int> pinFalls){
		ActionMaster tmpAM = new ActionMaster();
		Action result = new Action();
		foreach (var fall in pinFalls)
		{
			result =tmpAM.Bowl(fall);
		}
		return result;
	}

	//TODO: make public
	public Action Bowl(int pins){
		if(pins < 0 || pins > 10)
			throw new UnityException("Incorrect number of pins to bowl.");
		Bowls[BowlNumber - 1] = pins;
		
		if(BowlNumber == 19){
			BowlNumber += 1;
			if (pins == 10){	
				IsBowl21stAwarded = true;
				return Action.Reset;
			}else
				return Action.Tidy;
		}
		if(BowlNumber == 20){
				BowlNumber += 1;
			if (Bowls[18] + Bowls[19] == 10 || pins == 10){
				IsBowl21stAwarded = true;
				return Action.Reset;
			}else if(IsBowl21stAwarded)
				return Action.Tidy;
			else
				return Action.EndGame;
		}
		if(BowlNumber == 21){
			return Action.EndGame;
		}
		return HandleFirstNineFrames(pins);

		throw new UnityException("Not sure what action to return.");
	}

	private Action HandleFirstNineFrames(int pins){
		if(BowlNumber % 2 != 0){//Mid frame or last frame.
			if(pins == 10){
				BowlNumber += 2;
				return Action.EndTurn;
			}
			else{
				BowlNumber += 1;
				return Action.Tidy;
			}
		}else if(BowlNumber % 2 == 0){//End of frame.
			BowlNumber += 1;
			return Action.EndTurn;
		}
		
		throw new UnityException("Not sure what action to return.");
	}
}
