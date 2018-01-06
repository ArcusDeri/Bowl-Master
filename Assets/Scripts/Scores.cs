using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scores : MonoBehaviour {

	public Text [] RollTexts, FrameTexts;

	// Use this for initialization
	void Start () {
		foreach(var textDisplay in RollTexts)
			textDisplay.text = "";
		foreach(var textDisplay in FrameTexts)
			textDisplay.text = "";
	}

	public void FillRolls(List<int> rolls){
		var scoresString = FormatRolls(rolls);
		for(int i = 0; i < scoresString.Length; i++){
			RollTexts[i].text = scoresString[i].ToString();
		}
	}
	
	public void FillFrames(List<int> frames){
		for(int i = 0; i < frames.Count; i++){
			FrameTexts[i].text = frames[i].ToString();
		}
	}
	public static string FormatRolls(List<int> rolls){
		string result = "";
		
		for(int i = 0; i < rolls.Count; i++){
			int box = i + 1;					//score box number
			if(rolls[i] == 0){
				result += "-";
			}
			else if(box % 2 == 0 && rolls[i-1] + rolls[i] == 10){//spare
				result =  result.Trim() + "/";
			}
			else if(rolls[i] == 10){						//strike
				result += "X";
			}
			else{
				result += rolls[i].ToString();	
			}
		}

		return result;
	}
}
