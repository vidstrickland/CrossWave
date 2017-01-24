﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	private bool leftSelected = false;
	private bool rightSelected = false;

	void Start(){
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load disabled, use a positive number in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		Debug.Log ("Level load requested for " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit();
	}

	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	public void CharacterSelectLeft(){
		leftSelected = true;
		CheckForBoth ();
	}

	public void CharacterSelectRight(){
		print ("Chris Selected");
		rightSelected = true;
		CheckForBoth ();
	}

	private void CheckForBoth(){
		if (rightSelected && leftSelected) {
			rightSelected = false;
			leftSelected = false;
			Application.LoadLevel("03 Arena Demo");
		}
	}
	public void DelayStart(){
		Invoke("LoadStart", 4f);
	}

	public void LoadStart(){
		Application.LoadLevel("01 Start");
	}
}