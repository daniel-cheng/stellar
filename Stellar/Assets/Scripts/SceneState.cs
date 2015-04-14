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
	public Transform freighter;
    public List<Autogunner> turrets;
	public GUIText debug;
	public UIHandler uiHandler;
	public GameObject raceMusic;
    public SceneFadeInOut sceneFader;

    private Transform player;

    void Start()
    {
        player = NetworkManager.player.transform;
        sceneIndex = 0;
		cameraState.SetCameraState (3, true);
        EventNotifier.OnMenuStateChange += OnMenuStateChange;
        EventNotifier.OnNetworkStateChange += OnNetworkStateChange;
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

            player.GetComponent<MouseAim>().enabled = false;
            player.GetComponent<ShootRound>().enabled = false;
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
        cameraState.SetCameraState(1, false);
        cameraState.SetCameraState(2, false);
        cameraState.SetCameraState(3, true);

        foreach (GameObject title in txt)
        {
            title.GetComponent<Renderer>().enabled = true;
        }
    }
    
	void OnMouseUp ()
	{
        ChangeScene(gameObject.tag);
    }

    void OnMenuStateChange(string scene)
    {
        ChangeScene(scene);
    }

    void ChangeScene (string scene)
	{
        foreach (GameObject title in txt) {
			title.GetComponent<Renderer>().enabled = false;		
		}
		if (scene == "Race") {
            sceneIndex = 1;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
			cameraState.SetCameraState (3, false);
			cameraState.SetCameraState (0, true);
			raceMusic.GetComponent<AudioSource>().enabled = true;
			player.GetComponent<MouseAim> ().enabled = true;
            player.GetComponent<ShootRound>().enabled = true;
			//freighter.GetComponent<Fly> ().enabled = false;
			//foreach (Renderer renderer in freighter.GetComponentsInChildren<Renderer>()) {
			//	renderer.enabled = !renderer.enabled;
			//}
		} else if (scene == "Trade") {
            sceneIndex = 2;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
			cameraState.SetCameraState (3, false);
			cameraState.SetCameraState (4, true);
			player.GetComponent<MouseAim> ().enabled = false;
			player.GetComponent<ShootRound> ().enabled = false;
			player.GetComponent<Fly> ().enabled = false;
            //foreach (Renderer renderer in player.GetComponentsInChildren<Renderer>())
            //{
            //    renderer.enabled = !renderer.enabled;
            //}
        }
        else if (scene == "Combat")
        {
            sceneIndex = 1;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
            cameraState.SetCameraState(3, false);
            cameraState.SetCameraState(0, true);
            raceMusic.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<MouseAim>().enabled = true;
            player.GetComponent<ShootRound>().enabled = true;
            foreach (Autogunner turret in turrets)
            {
                turret.isEnabled = !turret.isEnabled;
            }
        }		
	}

    void OnNetworkStateChange()
    {
        player = NetworkManager.player.transform;
    }
}
