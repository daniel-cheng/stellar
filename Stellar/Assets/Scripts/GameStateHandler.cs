using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;

public class GameStateHandler : MonoBehaviour {
	//public GameObject[] gatePassedList = new GameObject[5]; //need some way to change size when need be
	public List<GameObject> gatePassedList;

	public float timeSinceStart = 0.0f;
	public int gatesPassed = 0;

	//gui texts for debugging purposes for now
	public GUIText outputGatesPassed;
	public GUIText debug;

	// Use this for initialization
	void Start () {
		//gateList = GameObject.FindGameObjectsWithTag ("Gate");
		gatePassedList = new List<GameObject> ();
	// 	commented these outs as they would appear in the main menu
	//	debug.text = "Beginning Game Testing!";
	//	outputGatesPassed.text = "Gates Passed: " + gatesPassed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trainingRings)
	{
		if(trainingRings.gameObject.tag == "Gate" &&
		   !gatePassedList.Contains(trainingRings.gameObject))
		{
			debug.text = "Ring Hit";
			gatePassedList.Add(trainingRings.gameObject);
			//trainingRings.gameObject.SetActive(false);
			gatesPassed += 1;
			outputGatesPassed.text = "Gates Passed: " + gatesPassed;
			
		}
	}
}
