using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void ClickStart(){
		SceneManager.LoadScene("Game",LoadSceneMode.Single);
	}

	public void ClickQuit(){
		Debug.Log("Quit requested.");
		Application.Quit();
	}

	public void ClickMainMenu(){
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}
}
