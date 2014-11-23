using UnityEngine;
using System.Collections.Generic;

public class SceneState : MonoBehaviour
{
	//public AudioClip mainMenuMusic; //not sure how to use this
	public List<string> sceneList = new List<string>{"main", "race", "trade"}; //for future use?
	public int sceneIndex = 0;

    public delegate void SceneTransition(int oldState, int newState);
    public static event SceneTransition OnSceneTransition;
	
	//references 
	public CameraState cameraState;
	public List<GameObject> txt;
	public Transform fighter;
	public Transform freighter;
	public GUIText debug;
	
	// Use this for initialization
	void Start ()
	{
		cameraState.SetCameraState (3, true);
	}
	
	// Update is called once per frame
	void Update ()
	{
//				if (Input.GetMouseButtonUp (0)) {
//						Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);						
//						RaycastHit hit = new RaycastHit();
//
//						if (Physics.Raycast (r, out hit)) {
//								Debug.Log ("Clicked!");
//								if (hit.transform.gameObject.tag == "Race") {
//										cameraState.SetCameraState (3, false);
//										cameraState.SetCameraState (0, true);
//										debug.text = "Race Module Initiated";
//								} else if (hit.transform.gameObject.tag == "Trade") {
//										debug.text = "Trade Module Initiated";
//								}
//			
//								foreach (GameObject title in txt) {
//										title.renderer.enabled = false;		
//								}
//						}
//				}
	}

	void OnMouseUp ()
	{
		foreach (GameObject title in txt) {
			title.renderer.enabled = false;		
		}

                
		if (gameObject.tag == "Race") {
            if (OnSceneTransition != null)
            {
                OnSceneTransition(0, 1);
            }

            cameraState.SetCameraState (3, false);
            cameraState.SetCameraState (0, true);
            debug.text = "Race Module Initiated";
            fighter.GetComponent<MouseAim> ().enabled = true;
            
            freighter.GetComponent<Fly> ().enabled = false;
            foreach (Renderer renderer in freighter.GetComponentsInChildren<Renderer>()) {
	            renderer.enabled = !renderer.enabled;
            }
		} else if (gameObject.tag == "Trade") {
            if (OnSceneTransition != null)
            {
                OnSceneTransition(0, 2);
            }
			cameraState.SetCameraState (3, false);
			cameraState.SetCameraState (4, true);
			debug.text = "Trade Module Initiated";
			fighter.renderer.enabled = false;
			fighter.GetComponent<MouseAim> ().enabled = false;
			fighter.GetComponent<Fly> ().enabled = false;
			foreach (Renderer renderer in fighter.GetComponentsInChildren<Renderer>()) {
				renderer.enabled = !renderer.enabled;
			}
						
		}

				
	}

	//will need to adjust when trade module is completed
	//debug.text = "Beginning Game Testing!";
		
}
