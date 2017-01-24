using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour {

	public float timeToDie = 1f;

	// Use this for initialization
	void Start () {
		Invoke ("DestroySparks", timeToDie);
	}
	
	void DestroySparks(){
		Destroy (gameObject);
	}
}
