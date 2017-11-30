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

		return frameList;
	}
}
