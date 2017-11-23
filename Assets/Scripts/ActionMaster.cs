using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame}
	
	private int BowlNumber = 1;
	private bool IsBowl21stAwarded = false;
	private int[] Bowls = new int [21];

	public Action Bowl(int pins){
		if(pins < 0 || pins > 10)
			throw new UnityException("Incorrect number of pins to bowl.");
		Bowls[BowlNumber - 1] = pins;

		if(BowlNumber == 19){
			BowlNumber += 1;
			if (Bowls[18] == 0){	
				IsBowl21stAwarded = true;
				return Action.Reset;
			}else
				return Action.Tidy;
		}
		if(BowlNumber == 20){
				BowlNumber += 1;
			if (Bowls[19] == 0){
				return Action.Reset;
			}else
			if(IsBowl21stAwarded)
				return Action.Reset;
			else
				return Action.EndGame;
		}
		if(BowlNumber == 21){
			return Action.EndGame;
		}

		if(pins == 10){
			BowlNumber += 2;
			return Action.EndTurn;
		}
		if(BowlNumber % 2 != 0){//Mid frame or last frame.
			BowlNumber += 1;
			return Action.Tidy;
		}else if(BowlNumber % 2 == 0){//End of frame.
			BowlNumber += 1;
			return Action.EndTurn;
		}

		throw new UnityException("Not sure what action to return.");
	}
}
