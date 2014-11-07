using UnityEngine;
using System.Collections.Generic;

public class SceneState : MonoBehaviour {
	public AudioClip mainMenuMusic;
	public List<string> sceneList = new List<string>{"main", "race", "trade"};
	public int sceneIndex = 0;
	CameraState cameraState;


	// Use this for initialization
	void Start () {
		cameraState.cameraList [3].enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void onMouseDown()
	{
		cameraState.cameraList [3].enabled = false;
		cameraState.cameraList [3].GetComponent<AudioSource>().enabled = false;
	}
}
