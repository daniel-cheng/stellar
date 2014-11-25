using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateHandler : MonoBehaviour {
    public delegate void StateChange();
    public static event StateChange OnTriggerStateChange;

	public List<GameObject> gatePassedList;

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

	// Use this for initialization
	void Start () {
		gatePassedList = new List<GameObject> ();
        cargoCarried = Random.Range(cargoMassBounds.x, cargoMassBounds.y);
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceStart += Time.deltaTime;
        distanceTravelled += rigidbody.velocity.magnitude * Time.deltaTime;

        uiHandler.SetLowerLeftText("Time: " + timeSinceStart.ToString("F2") + " Velocity: " + rigidbody.velocity.magnitude.ToString("F2"));
	}

    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Gate" && !gatePassedList.Contains(other.gameObject))
		{
            gatePassedList.Add(other.gameObject);
			gatesPassed += 1;

            uiHandler.SetUpperRightText("Ring Hit");
            uiHandler.SetUpperLeftText("Gates Passed: " + gatesPassed.ToString());
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
}
