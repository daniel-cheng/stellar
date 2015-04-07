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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void OnStateChange()
    {
        if (SceneState.sceneIndex != 0)
        {
            isEnabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isEnabled = false; 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}