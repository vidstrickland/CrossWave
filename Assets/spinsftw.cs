using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinsftw : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

void Update () {
	transform.Rotate(Vector3.up, 10.0f * Time.deltaTime);
}
}