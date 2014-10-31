using UnityEngine;
using System.Collections.Generic;

public class CameraState : MonoBehaviour {
	//use to switch between camera states
	private int stateIndex = 0;
	//use to store all three camera states
    public List<Camera> cameraList;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.C))
		{
            foreach (Camera camera in cameraList)
            {
                camera.enabled = false;
                camera.transform.GetComponent<AudioListener>().enabled = false;
            }
			
            if (stateIndex != 2)
            {
                stateIndex++;
            }
            else
            {
                stateIndex = 0;
            }
		}
		cameraList[stateIndex].enabled = true;
        cameraList[stateIndex].transform.GetComponent<AudioListener>().enabled = true;
	
	}
}
