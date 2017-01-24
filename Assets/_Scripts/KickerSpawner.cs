using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickerSpawner : MonoBehaviour {

	public GameObject puckKicker;
	public GameObject waveRing;

	public Camera camera;
	GameObject lcm;
	GameObject rcm;

	float lcmTotal = GameObject.Find("LeftChargeMeter").GetComponent<ChargeMeter>().barDisplay;
	float rcmTotal = GameObject.Find("RightChargeMeter").GetComponent<ChargeMeter>().barDisplay;

	private float xPos;

	// Use this for initialization
	void Start () {
		//lcm = Instantiate (leftChargeMeter) as GameObject;
		//rcm = Instantiate (rightChargeMeter) as GameObject;
		lcm = GameObject.Find("LeftChargeMeter");
		rcm = GameObject.Find("RightChargeMeter");
	}
	
	// Update is called once per frame
	void Update () {

		lcmTotal = GameObject.Find("LeftChargeMeter").GetComponent<ChargeMeter>().barDisplay;
		rcmTotal = GameObject.Find("RightChargeMeter").GetComponent<ChargeMeter>().barDisplay;
		/*if (Input.GetMouseButtonDown(0)) {
			print ("Kick!");
			GameObject Kicker = Instantiate (puckKicker)  as GameObject;
			puckKicker.transform.position = new Vector3(Input.mousePosition.x, 0.1f, Input.mousePosition.z);
			*/

		if (Input.GetMouseButtonDown(0)) {
			Vector3 p = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10.0f));
			//print(p);
			xPos = p.x;
			//print(p.y);


			if (xPos < 0) {
					if (lcmTotal >= .2f) {
					Instantiate(waveRing,new Vector3(p.x,0.1f,p.z),Quaternion.Euler(90, 0, 0));
						lcm.GetComponent<ChargeMeter> ().Deplete ();
						print ("left side");
						xPos = 0;
						Instantiate(puckKicker,new Vector3(p.x,0.1f,p.z),Quaternion.identity);
					}
				} else if (xPos > 0) {
					if (rcmTotal >= .2f) {
					Instantiate(waveRing,new Vector3(p.x,0.1f,p.z),Quaternion.Euler(90, 0, 0));
						rcm.GetComponent<ChargeMeter>().Deplete ();
						print ("right side");
						xPos = 0;
						Instantiate(puckKicker,new Vector3(p.x,0.1f,p.z),Quaternion.identity);
					}
				}
			}
		}
	}
