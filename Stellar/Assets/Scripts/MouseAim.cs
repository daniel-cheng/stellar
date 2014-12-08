using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {

	public bool isEnabled;

	// Use this for initialization
	void Start () {
        SceneState.OnStateChange += OnStateChange;
        CameraState.OnStateChange += OnStateChange;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isEnabled) 
		{
            transform.localRotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
		}
	}

    void OnStateChange()
    {
        if (SceneState.sceneIndex == 1)
        {
            if (CameraState.stateIndex == 1)
            {
                isEnabled = false;
            }
            else
            {
                isEnabled = true;
            }
        }
        else
        {
            isEnabled = false;
        }
    }
}
