﻿using UnityEngine;
using System.Collections.Generic;

public class CameraState : MonoBehaviour {
	//use to switch between camera states
	
	//use to store all camera states
    public List<GameObject> cameraObjectList;
    public List<int> transitionList = new List<int>() {1, 2, 0, 3};
    private int stateIndex = 3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.C))
		{
            SetCameraState(stateIndex, false);
            stateIndex = transitionList[stateIndex];
			//with scenestate, camera will only need to be enabled when the camera is changing
            SetCameraState(stateIndex, true);
		}
	}

    public void SetCameraState(int cameraIndex, bool state)
    {
        Debug.Log(cameraIndex.ToString() + " " + state.ToString());
        stateIndex = cameraIndex;
        cameraObjectList[cameraIndex].GetComponent<AudioListener>().enabled = state;
        foreach (Camera camera in cameraObjectList[cameraIndex].GetComponentsInChildren<Camera>())
        {
            camera.enabled = state;
        }
    }
}
