using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int leftScore = 0;
	public int rightScore = 0;
	public int winScore = 5;

	public float animationDelay = 0f;

	public string leftPlayerName = "Radd Excellence";
	public string rightPlayerName = "Ice E. Cool";

	public LevelManager levelManager;

	public Text leftPlayerScore;
	public Text rightPlayerScore;

	public Camera mainCamera;
	public Camera crowdCamera;
	public GameObject goalSparks;


	// Use this for initialization
	void Start () {
		mainCamera.enabled = true;
		crowdCamera.enabled = false;

		leftPlayerScore.text = leftPlayerName + ": " + leftScore.ToString();
		rightPlayerScore.text = rightPlayerName + ": " + rightScore.ToString();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.C)) {
			mainCamera.enabled = !mainCamera.enabled;
			crowdCamera.enabled = !crowdCamera.enabled;
		}
	}

	// Update is called once per frame
	public void leftScoreUpdate () {
		leftScore++;
		CameraChange ();
		Invoke ("CameraChange", 2f);
		Invoke("leftScoreAnimate", animationDelay);
		CheckWin ();
		GameObject leftSparks = Instantiate (goalSparks) as GameObject;
		leftSparks.transform.position = new Vector3 (7.88f, 1.20f, 0f);
		GameObject rightSparks = Instantiate (goalSparks) as GameObject;
		rightSparks.transform.position = new Vector3 (-7.88f, 1.20f, 0f);
	}

	public void rightScoreUpdate () {
		rightScore++;
		CameraChange ();
		Invoke ("CameraChange", 2f);
		Invoke("rightScoreAnimate", animationDelay);
		CheckWin ();
		GameObject rightSparks = Instantiate (goalSparks) as GameObject;
		rightSparks.transform.position = new Vector3 (-7.88f, 1.20f, 0f);
		GameObject leftSparks = Instantiate (goalSparks) as GameObject;
		leftSparks.transform.position = new Vector3 (7.88f, 1.20f, 0f);
	}

	public void leftScoreAnimate(){
		leftPlayerScore.text = leftPlayerName + ": " + leftScore.ToString();
	}

	public void rightScoreAnimate(){
		rightPlayerScore.text = rightPlayerName + ": " + rightScore.ToString();
	}

	void CheckWin(){
		if (leftScore >= winScore) {
			LeftPlayerWins ();
		} else if (rightScore >= winScore) {
			RightPlayerWins ();
		}
	}

	void LeftPlayerWins(){
		levelManager.LoadLevel ("04a RaddWin");
	}

	void RightPlayerWins(){
		levelManager.LoadLevel ("04b IceWin");
	}

	void CameraChange(){
		mainCamera.enabled = !mainCamera.enabled;
		crowdCamera.enabled = !crowdCamera.enabled;
	}
}
