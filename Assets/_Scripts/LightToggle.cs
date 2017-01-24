using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {

	private Light myLight;

	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light>();
		if (!myLight.enabled) {
			myLight.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
