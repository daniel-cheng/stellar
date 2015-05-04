using UnityEngine;
using System.Collections.Generic;

public class CameraState : MonoBehaviour {
	//use to store all camera states
    public List<GameObject> cameraObjectList;
    public List<int> transitionList = new List<int>() {1, 2, 0, 3, 4};
    public static int stateIndex = 3;

    public delegate void StateChange();
    public static event StateChange OnStateChange;

    private Transform player;

	// Use this for initialization
	void Start () {
        player = NetworkManager.player.transform;
        EventNotifier.OnNetworkStateChange += OnNetworkStateChange;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
		{
            SetCameraState(stateIndex, false);
			//with scenestate, camera will only need to be enabled when the camera is changing
            SetCameraState(transitionList[stateIndex], true);
		}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Debug.Log("Hello");
        //    cameraObjectList[stateIndex].GetComponent<MouseOrbit>().isEnabled = true;
        //    if (cameraObjectList[stateIndex].GetComponent<GunnerAim>())
        //    {
        //        cameraObjectList[stateIndex].GetComponent<GunnerAim>().isEnabled = false;
        //    }
        //    player.GetComponent<MouseAim>().isEnabled = false;
        //}
        //if (Input.GetKeyUp(KeyCode.C))
        //{
        //    cameraObjectList[stateIndex].GetComponent<MouseOrbit>().isEnabled = false;
        //    if (cameraObjectList[stateIndex].GetComponent<GunnerAim>())
        //    {
        //        cameraObjectList[stateIndex].GetComponent<GunnerAim>().isEnabled = true;
        //    }
        //    player.GetComponent<MouseAim>().isEnabled = true;
        //}
	}

    public void SetCameraState(int cameraIndex, bool state)
    {
        stateIndex = cameraIndex;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
        cameraObjectList[stateIndex].GetComponent<AudioListener>().enabled = state;
        if (stateIndex == 1)
        {
            cameraObjectList[stateIndex].GetComponent<GunnerAim>().isEnabled = state;
        }
        else if (stateIndex == 0)
        {
            //cameraObjectList[stateIndex].GetComponentInParent<MouseAim>().isEnabled = state;
        }
        foreach (Camera camera in cameraObjectList[stateIndex].GetComponentsInChildren<Camera>())
        {
            camera.enabled = state;
        }
    }

    void OnNetworkStateChange()
    {
        player = NetworkManager.player.transform;
    }
}
