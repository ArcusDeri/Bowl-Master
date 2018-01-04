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
	
	// Update is called once per frame
	void Update () {
		
	}
}
