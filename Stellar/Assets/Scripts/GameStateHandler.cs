using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateHandler : MonoBehaviour {
    public delegate void StateChange();
    public static event StateChange OnTriggerStateChange;

    public SceneState sceneState;
	public List<GameObject> gatePassedList;
    public Vector3 storedPosition;
    public Quaternion storedRotation;

	public float timeSinceStart = 0.0f;
	public int gatesPassed = 0;

	//gui texts for debugging purposes for now
	public UIHandler uiHandler;

    public float distanceTravelled = 0.0f;
    public float cargoCarried = 0.0f;
    public float cargoDelivered = 0.0f;
    public List<Transform> tradingPostList;
    public int tradingPostDestinationIndex;

    private Vector2 cargoMassBounds = new Vector2(1000.0f, 100000.0f);
	private GameObject[] numOfGates;
	private int countLength = 0;
	private int lap = 0;

	// Use this for initialization
	void Start () {
        storedPosition = transform.position;
        storedRotation = transform.rotation;
		numOfGates = GameObject.FindGameObjectsWithTag("Gate");
		countLength = numOfGates.Length;
    	//uiHandler.SetUpperRightText("Number of rings: " + (countLength - 1));
		gatePassedList = new List<GameObject> ();
        cargoCarried = Random.Range(cargoMassBounds.x, cargoMassBounds.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneState.sceneIndex != 0) {
						timeSinceStart += Time.deltaTime;
						distanceTravelled += rigidbody.velocity.magnitude * Time.deltaTime;
						uiHandler.SetLowerLeftText ("Time: " + timeSinceStart.ToString ("F2") + " Velocity: " + rigidbody.velocity.magnitude.ToString ("F2"));
				}
	}

    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Gate" && !gatePassedList.Contains(other.gameObject))
		{
            gatePassedList.Add(other.gameObject);
			gatesPassed += 1;

			if(gatesPassed > countLength-2)
			{
				lap++;
				if(lap > 1)
				{
                    sceneState.SetSceneState(0, true);
                    Initialize();
				}
				gatesPassed = 0;
				gatePassedList.Clear();
			}

            uiHandler.SetUpperLeftText("Gates Passed: " + gatesPassed.ToString() + "\nLaps Passed: "
			                           + lap);
            if (OnTriggerStateChange != null)
            {
                OnTriggerStateChange();
            }
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
            if (OnTriggerStateChange != null)
            {
                OnTriggerStateChange();
            }
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
        countLength = 0;
        transform.position = storedPosition;
        transform.rotation = storedRotation;
    }
}
