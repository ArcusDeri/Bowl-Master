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

	//returns list of individual frame scores, not cumulative
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frameList = new List<int>();
		int firstBowl = -1;
		int secondBowl = -1;
		int extraScore = 0;
		bool isWaitingForNext = false;
		
		foreach (int score in rolls)
		{
			if(isWaitingForNext){
				if(score < 10){
					extraScore += score;
				}
			}	
			if(firstBowl >= 0){
				if(secondBowl >= 0){
					frameList.Add(firstBowl + secondBowl);
					firstBowl = score;
					secondBowl = -1;
				}else{
					secondBowl = score;
					frameList.Add(firstBowl + secondBowl);
					firstBowl = -1;
					secondBowl = -1;
				}
			}else {
				if(score == 10){
					extraScore += 10;
				}else{
					firstBowl = score;
				}
			}
		}

		
		return frameList;
	}
}
