using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame}
	
	private int BowlNumber = 1;

	public Action Bowl(int pins){
		if(pins < 0 || pins > 10)
			throw new UnityException("Incorrect number of pins to bowl.");
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
