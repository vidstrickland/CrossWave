using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

	public ScoreManager scoreManager;

	public GameObject PuckObject;

	public AudioClip goalSound;

	public AudioSource goalAudio;

	// Use this for initialization
	void Start () {
		goalAudio = GetComponent<AudioSource> ();
		PuckObject = GameObject.Find ("Puck");
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collision){
		goalAudio.clip = goalSound;
		goalAudio.Play ();
		if (collision.gameObject.tag == "Right Goal") {
			PuckObject.GetComponent<Puck> ().DestroyPuck ();
			print ("Left Player Scored");
			scoreManager.leftScoreUpdate ();
			PuckReturn ();
			Invoke("PuckReturn", 3f);
		} else if (collision.gameObject.tag == "Left Goal") {
			PuckObject.GetComponent<Puck> ().DestroyPuck ();
			print("Right Player Scored");
			scoreManager.rightScoreUpdate ();
			PuckReturn ();
			Invoke("PuckReturn", 3f);
		}
	}

	void PuckReturn(){
		GameObject newPuck = Instantiate (PuckObject) as GameObject;
		newPuck.transform.position = new Vector3 (0f, .5f, 0f);
	}
}
