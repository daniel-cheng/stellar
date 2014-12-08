using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {
	
	public GUIText upperRight;
    public GUIText upperLeft;
    public GUIText lowerRight;
    public GUIText lowerLeft;
	
	// Use this for initialization
	void Start () {
        SceneState.OnStateChange += OnStateChange;
        CameraState.OnStateChange += OnStateChange;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetUpperRightText(string text) {
        upperRight.text = text;
	}

    public void SetUpperLeftText(string text)
    {
        //upperLeft.text = text;
    }

    public void SetLowerRightText(string text)
    {
        lowerRight.text = text;
    }

    public void SetLowerLeftText(string text)
    {
        lowerLeft.text = text;
    }

    void OnStateChange()
    {
        if (SceneState.sceneIndex == 1)
        {
            //SetUpperRightText("Race Module Initiated");
        }
        else if (SceneState.sceneIndex == 2)
        {
            //SetUpperRightText("Trade Module Initiated");
        }
        else if (SceneState.sceneIndex == 0)
        {
            SetUpperRightText("");
            SetUpperLeftText("");
            SetLowerRightText("");
            SetLowerLeftText("");
        }
    }
}