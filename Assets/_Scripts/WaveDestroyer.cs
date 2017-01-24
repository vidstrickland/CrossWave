using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyWave", 2f);	
	}
	
	// Update is called once per frame
	void DestroyWave () {
		Destroy (gameObject);
	}
}
