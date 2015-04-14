using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateHandler : MonoBehaviour {
    public SceneState sceneState;
	public StatSystem statSystem;
    public UIHandler uiHandler;
	public List<GameObject> gatePassedList;
    public Vector3 storedPosition;
    public Quaternion storedRotation;

	public float timeSinceStart = 0.0f;
	public int gatesPassed = 0;
    public int enemyCount = 0;
    public float distanceTravelled = 0.0f;
    public float cargoCarried = 0.0f;
    public float cargoDelivered = 0.0f;
    public List<Transform> tradingPostList;
    public int tradingPostDestinationIndex;
    public int gatesCount = 0;
    public Vector2 cargoMassBounds = new Vector2(1000.0f, 100000.0f);

	private int lap = 0;
    private Transform player;

	// Use this for initialization
	void Start () {
        player = NetworkManager.player.transform;
        storedPosition = player.position;
        storedRotation = player.rotation;
        gatesCount = GameObject.FindGameObjectsWithTag("Gate").Length;
        enemyCount = GameObject.FindGameObjectsWithTag("Turret").Length;
    	//uiHandler.SetUpperRightText("Number of rings: " + (gatesCount - 1));
		gatePassedList = new List<GameObject> ();
        cargoCarried = Random.Range(cargoMassBounds.x, cargoMassBounds.y);
        EventNotifier.OnTriggerStateChange += OnTriggerStateChange;
        EventNotifier.OnDestroyStateChange += OnDestroyStateChange;
        EventNotifier.OnNetworkStateChange += OnNetworkStateChange;
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneState.sceneIndex != 0) {
			timeSinceStart += Time.deltaTime;
			distanceTravelled += player.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;
			uiHandler.SetLowerLeftText ("Time: " + timeSinceStart.ToString ("F2") + " Velocity: " + player.GetComponent<Rigidbody>().velocity.magnitude.ToString ("F2"));
			uiHandler.SetBottomLeftText("Health: " + statSystem.health.ToString("F2"));
            uiHandler.SetUpperLeftText("Turrets Remaining: " + enemyCount.ToString());
		}
	}

    void OnTriggerStateChange(Collider other)
    {
        OnObjectEnter(other);
    }

    void OnDestroyStateChange()
    {
        OnObjectDestoryed();
    }

    void OnObjectDestoryed()
    {
        enemyCount--;
        uiHandler.SetUpperLeftText("Turrets Remaining: " + enemyCount.ToString());
        if (enemyCount <= 0)
        {
            sceneState.SetSceneState(0, true);
            Initialize();
        }
    }

    void OnObjectEnter (Collider other)
	{
        if (other.gameObject.tag == "Gate" && !gatePassedList.Contains(other.gameObject))
		{
            gatePassedList.Add(other.gameObject);
			gatesPassed += 1;

			if(gatesPassed >= gatesCount)
			{
				lap++;
				if(lap > 0)
				{
                    sceneState.SetSceneState(0, true);
                    Initialize();
				}
				gatesPassed = 0;
				gatePassedList.Clear();
			}

            uiHandler.SetUpperLeftText("Gates Passed: " + gatesPassed.ToString() + "\nLaps Passed: "
			                           + lap);
            //if (OnTriggerStateChange != null)
            //{
            //    OnTriggerStateChange();
            //}
		}
        else if (other.transform == tradingPostList[tradingPostDestinationIndex])
        {
            cargoDelivered += cargoCarried;
            cargoCarried = Random.Range(cargoMassBounds.x, cargoMassBounds.y);

            int randomIndex = tradingPostDestinationIndex;
            while (randomIndex == tradingPostDestinationIndex)
            {
                randomIndex = (int)Random.Range(0.0f, tradingPostList.Capacity);
            }
            tradingPostDestinationIndex = randomIndex;

            uiHandler.SetLowerRightText("Cargo Carried: " + cargoCarried.ToString("G2") + " Delivered: " + cargoDelivered.ToString("G2"));
            //if (OnTriggerStateChange != null)
            //{
            //    OnTriggerStateChange();
            //}
        }
	}

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5.0f);
    }

    void Initialize()
    {
        timeSinceStart = 0.0f;
	    gatesPassed = 0;
        distanceTravelled = 0.0f;
        cargoCarried = 0.0f;
        cargoDelivered = 0.0f;
        lap = 0;
        gatesCount = GameObject.FindGameObjectsWithTag("Gate").Length;
        enemyCount = GameObject.FindGameObjectsWithTag("Turret").Length;
        player.position = storedPosition;
        player.rotation = storedRotation;
    }

    void OnNetworkStateChange()
    {
        Debug.Log("Hello1");
        player = NetworkManager.player.transform;
    }
}