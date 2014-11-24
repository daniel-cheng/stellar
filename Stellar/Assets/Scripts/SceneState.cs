using UnityEngine;
using System.Collections.Generic;

public class SceneState : MonoBehaviour
{
	//public AudioClip mainMenuMusic; //not sure how to use this
	public List<string> sceneList = new List<string>{"main", "race", "trade"}; //for future use?
	public static int sceneIndex = 0;

    public delegate void StateChange();
    public static event StateChange OnStateChange;
	
	//references 
	public CameraState cameraState;
	public List<GameObject> txt;
	public Transform fighter;
	public Transform freighter;
	public GUIText debug;
	public UIHandler uiHandler;

	// Use this for initialization
	void Start ()
	{
		cameraState.SetCameraState (3, true);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnMouseUp ()
	{
		foreach (GameObject title in txt) {
			title.renderer.enabled = false;		
		}
		if (gameObject.tag == "Race") {
            sceneIndex = 1;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
			cameraState.SetCameraState (3, false);
			cameraState.SetCameraState (0, true);
			fighter.GetComponent<MouseAim> ().enabled = true;
            fighter.GetComponent<ShootRound>().enabled = true;
			freighter.GetComponent<Fly> ().enabled = false;
			foreach (Renderer renderer in freighter.GetComponentsInChildren<Renderer>()) {
				renderer.enabled = !renderer.enabled;
			}
		} else if (gameObject.tag == "Trade") {
            sceneIndex = 2;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
			cameraState.SetCameraState (3, false);
			cameraState.SetCameraState (4, true);
			fighter.renderer.enabled = false;
			fighter.GetComponent<MouseAim> ().enabled = false;
			fighter.GetComponent<ShootRound> ().enabled = false;
			fighter.GetComponent<Fly> ().enabled = false;
            foreach (Renderer renderer in fighter.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = !renderer.enabled;
            }
        }						
	}	
}
