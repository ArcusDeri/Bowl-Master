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
		int scoreInFrame = 0;
		int extraStrikeScore = 0;
		int strikeAccumulator = 0;
		int lastFrameAccumulator = 0;
		bool isSpare = false;
		bool isStrike = false;
		bool isZero = false;
		bool isLastTwo = false;
		
		foreach (int score in rolls)
		{
			if(lastFrameAccumulator > 1)
				isLastTwo = true;
			if(frameList.Count() == 9)
				lastFrameAccumulator++;

			if(isSpare){
				frameList.Add(scoreInFrame + score);
				scoreInFrame = 0;
				isSpare = false;
			}else
			if(isStrike){
				if(score != 10){
					extraStrikeScore += score;
				}else{
					if(strikeAccumulator % 30 == 0){
						frameList.Add(30);
						strikeAccumulator += 20;	
						if(score + strikeAccumulator == 300){
							frameList.Add(30);
						}
					}
				}
				if(scoreInFrame > 0){
					if(extraStrikeScore < 20){
						frameList.Add(extraStrikeScore);
						extraStrikeScore = 0;
						isStrike = false;
					}
					else{
						frameList.Add(extraStrikeScore - score);
						frameList.Add(scoreInFrame + score + 10);
						frameList.Add(scoreInFrame + score);
						scoreInFrame = 0;
						extraStrikeScore = 0;
						continue;
					}
				}
			}else
			if(isZero && score == 0){
				frameList.Add(0);
				isZero = false;
				continue;
			}

			if(score == 10){
				isStrike = true;
				strikeAccumulator += 10;
				extraStrikeScore += score;
			}else
			if(score == 0){
				isZero = true;
			}else 
			if(scoreInFrame + score == 10){
				isSpare = true;
				scoreInFrame += score;
			}else
			if(scoreInFrame > 0){
				if(!isLastTwo)
					frameList.Add(scoreInFrame + score);
				scoreInFrame = 0;
			}
			else{
				scoreInFrame += score;
			}

		}

		
		return frameList;
	}
}
