using UnityEngine;
using System.Collections;

public class ScreenLock : MonoBehaviour {
    public bool isEnabled;

	void Start() {
        SceneState.OnStateChange += OnStateChange;
        CameraState.OnStateChange += OnStateChange;
	}
	
    void Update() {
        if (isEnabled) {
            if (Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.P))
            {
                Screen.lockCursor = false;
                Screen.showCursor = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Screen.lockCursor = true;
            }
        }
    }

    void OnStateChange()
    {
        if (SceneState.sceneIndex != 0)
        {
            isEnabled = true;
            Screen.lockCursor = true;
        }
        else
        {
            isEnabled = false;
        }
    }
}