using UnityEngine;
using System.Collections;

public class ScreenLock : MonoBehaviour {
	void Start() { 
		Screen.lockCursor = false;
//		Screen.showCursor = false;
	}
	
    void Update() {
        if (Input.GetKeyDown("escape")||Input.GetKeyDown(KeyCode.P)) {
            Screen.lockCursor = false;
			Screen.showCursor = true;
		}
		if (Input.GetMouseButtonDown(0)) {
			Screen.lockCursor = true;
		}
    }
}