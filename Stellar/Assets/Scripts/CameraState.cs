using UnityEngine;
using System.Collections.Generic;

public class CameraState : MonoBehaviour {
	//use to switch between camera states
	
	//use to store all camera states
    public List<GameObject> cameraObjectList;
    public List<int> transitionList = new List<int>() {1, 2, 0, 3, 4};
    private int stateIndex = 3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.C))
		{
            SetCameraState(stateIndex, false);
			//with scenestate, camera will only need to be enabled when the camera is changing
            SetCameraState(transitionList[stateIndex], true);
		}
	}

    public void SetCameraState(int cameraIndex, bool state)
    {
        stateIndex = cameraIndex;
        cameraObjectList[stateIndex].GetComponent<AudioListener>().enabled = state;
        cameraObjectList[stateIndex].GetComponent<MouseOrbit>().isEnabled = state;
        if (stateIndex == 1)
        {
            cameraObjectList[stateIndex].GetComponent<GunnerAim>().isEnabled = state;
        }
        else if (stateIndex == 0)
        {
            cameraObjectList[stateIndex].GetComponent<MouseAim>().isEnabled = state;
        }
        foreach (Camera camera in cameraObjectList[stateIndex].GetComponentsInChildren<Camera>())
        {
            camera.enabled = state;
        }
    }
}
