﻿using UnityEngine;
using System.Collections.Generic;

public class SceneState : MonoBehaviour
{
		//public AudioClip mainMenuMusic; //not sure how to use this
		//public List<string> sceneList = new List<string>{"main", "race", "trade"}; //for future use?
		//public int sceneIndex = 0;
	
		//references 
		public CameraState cameraState;
		public List<GameObject> txt;
		public Transform fighter;
		public Transform freighter;
		public GUIText debug;
		public UIHandler UIhandler;
	
		// Use this for initialization
		void Start ()
		{
				cameraState.SetCameraState (3, true);
		}
	
		// Update is called once per frame
		void Update ()
		{
//				if (Input.GetMouseButtonUp (0)) {
//						Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);						
//						RaycastHit hit = new RaycastHit();
//
//						if (Physics.Raycast (r, out hit)) {
//								Debug.Log ("Clicked!");
//								if (hit.transform.gameObject.tag == "Race") {
//										cameraState.SetCameraState (3, false);
//										cameraState.SetCameraState (0, true);
//										debug.text = "Race Module Initiated";
//								} else if (hit.transform.gameObject.tag == "Trade") {
//										debug.text = "Trade Module Initiated";
//								}
//			
//								foreach (GameObject title in txt) {
//										title.renderer.enabled = false;		
//								}
//						}
//				}
		}

		void OnMouseUp ()
		{
				foreach (GameObject title in txt) {
					title.renderer.enabled = false;		
				}

				if (gameObject.tag == "Race") {
						cameraState.SetCameraState (3, false);
						cameraState.SetCameraState (0, true);
						UIhandler.SetText("Race Module Initiated");
						fighter.GetComponent<MouseAim> ().enabled = true;
                        fighter.GetComponent<ShootRound>().enabled = true;
						freighter.GetComponent<Fly> ().enabled = false;
						foreach (Renderer renderer in freighter.GetComponentsInChildren<Renderer>()) {
							renderer.enabled = !renderer.enabled;
						}
				} else if (gameObject.tag == "Trade") {
						cameraState.SetCameraState (3, false);
						cameraState.SetCameraState (4, true);
						UIhandler.SetText("Trade Module Initiated");
						fighter.renderer.enabled = false;
						fighter.GetComponent<MouseAim> ().enabled = false;
						fighter.GetComponent<ShootRound> ().enabled = false;
						fighter.GetComponent<Fly> ().enabled = false;
						foreach (Renderer renderer in fighter.GetComponentsInChildren<Renderer>()) {
							renderer.enabled = !renderer.enabled;
						}
						
				}

				
		}

		//will need to adjust when trade module is completed
	   //UIhandler.SetText("Beginning Game Testing!");
		
}
