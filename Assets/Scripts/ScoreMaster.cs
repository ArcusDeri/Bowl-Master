using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreMaster {
	
	//returns list of cumulative scores like a nomral score card
	public static List<int> ScoreCumulative(List<int> rolls){
		var cumulativeScores = new List<int>();
		int runningTotal = 0;
		foreach (int frameScore in ScoreFrames(rolls))
		{
			runningTotal += frameScore;
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}

	//returns list of individual frame scores
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frames = new List<int>();
		
		//i points to second bowl of frame
		for(int i = 1; i < rolls.Count; i+=2 ){
			if(frames.Count == 10)						//prevents 11th frame score
				break;
			if(rolls[i - 1] + rolls[i] < 10){			//standard frame
				frames.Add(rolls[i - 1] + rolls[i]);
			}

			if(rolls.Count - i <= 1)					//there is no i+1 index
				break;

			if(rolls[i - 1] == 10){						//strike
				i--;									//strike frame has just one bowl
				frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
			}else if(rolls[i - 1] + rolls[i] == 10){			//spare bonus
				frames.Add(10 + rolls[i + 1]);
			}
		}


		return frames;
	}
}
