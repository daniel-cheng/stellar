using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneState : MonoBehaviour
{
	//public AudioClip raceMusic; //not sure how to use this
	public List<string> sceneList = new List<string>{"main", "race", "trade", "combat"}; //for future use?
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
	public GameObject raceMusic;
    public SceneFadeInOut sceneFader;

    void Awake()
    {
        sceneIndex = 0;
		cameraState.SetCameraState (3, true);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
    public void SetSceneState(int stateIndex, bool state)
    {
        sceneIndex = stateIndex;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
        if (stateIndex == 0)
        {
            sceneFader.EndScene();

            fighter.GetComponent<MouseAim>().enabled = false;
            fighter.GetComponent<ShootRound>().enabled = false;
            uiHandler.SetLowerRightText("Yay you won!!!");
            StartCoroutine(SwitchCamera());

        }
    }

    IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(2.5f);
        raceMusic.GetComponent<AudioSource>().enabled = false;
        sceneFader.StartScene();
        cameraState.SetCameraState(0, false);
        cameraState.SetCameraState(3, true);

        foreach (GameObject title in txt)
        {
            title.renderer.enabled = true;
        }
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
			raceMusic.GetComponent<AudioSource>().enabled = true;
			fighter.GetComponent<MouseAim> ().enabled = true;
            fighter.GetComponent<ShootRound>().enabled = true;
			//freighter.GetComponent<Fly> ().enabled = false;
			//foreach (Renderer renderer in freighter.GetComponentsInChildren<Renderer>()) {
			//	renderer.enabled = !renderer.enabled;
			//}
		} else if (gameObject.tag == "Trade") {
            sceneIndex = 2;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
			cameraState.SetCameraState (3, false);
			cameraState.SetCameraState (4, true);
			fighter.GetComponent<MouseAim> ().enabled = false;
			fighter.GetComponent<ShootRound> ().enabled = false;
			fighter.GetComponent<Fly> ().enabled = false;
            //foreach (Renderer renderer in fighter.GetComponentsInChildren<Renderer>())
            //{
            //    renderer.enabled = !renderer.enabled;
            //}
        }						
	}	
}
