using UnityEngine;
using System.Collections.Generic;

public class SceneState : MonoBehaviour {
	//public AudioClip mainMenuMusic; //not sure how to use this

	//public List<string> sceneList = new List<string>{"main", "race", "trade"}; //for future use?
	//public int sceneIndex = 0;

	//references 
	public CameraState cameraState;
	public GameObject titleTxt;
	public GameObject tradeTxt;
	public GameObject raceTxt;
	
	public GUIText debug;

	// Use this for initialization
	void Start () {
		cameraState.cameraList [3].enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		Debug.Log ("Clicked!");

		//temprorary method of clearing menu
		titleTxt.renderer.enabled = false;
		tradeTxt.renderer.enabled = false;
		gameObject.renderer.enabled = false;

		//changing camera state to race module
		cameraState.cameraList [3].enabled = false;
		cameraState.cameraList [3].GetComponent<AudioListener> ().enabled = false;
		cameraState.cameraList [0].enabled = true;
		cameraState.cameraList [0].transform.GetComponent<AudioListener>().enabled = true;

		//will need to adjust when trade module is completed
		debug.text = "Beginning Game Testing!";
	}
}
