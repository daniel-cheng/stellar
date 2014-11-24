using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateHandler : MonoBehaviour {
	public List<GameObject> gatePassedList;

	public float timeSinceStart = 0.0f;
	public int gatesPassed = 0;

	//gui texts for debugging purposes for now
	public GUIText outputGatesPassed;
	public GUIText debug;
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

	// 	commented these outs as they would appear in the main menu
	//	debug.text = "Beginning Game Testing!";
	//	outputGatesPassed.text = "Gates Passed: " + gatesPassed;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceStart += Time.deltaTime;
        distanceTravelled += rigidbody.velocity.magnitude * Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Gate" && !gatePassedList.Contains(other.gameObject))
		{
			uiHandler.SetText("Ring Hit");
            gatePassedList.Add(other.gameObject);
			//trainingRings.gameObject.SetActive(false);
			gatesPassed += 1;
			outputGatesPassed.text = "Gates Passed: " + gatesPassed;
			
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
        }
	}
}
