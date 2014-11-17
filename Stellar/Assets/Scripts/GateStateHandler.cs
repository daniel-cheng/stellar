using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GateStateHandler : MonoBehaviour {
	public float distanceTravelled = 0.0f;
	public float cargoCarried = 0.0f;
	public float cargoDelivered = 0.0f;
	public List<Transform> tradingPostList;
	public int tradingPostDestinationIndex;

	private Vector2 cargoMassBounds = new Vector2(1000.0f, 100000.0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float timeSinceStart = 0.0f;
		timeSinceStart += Time.deltaTime;
		distanceTravelled += rigidbody.velocity.magnitude * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		if (other == tradingPostList[tradingPostDestinationIndex]){
			cargoDelivered += cargoCarried;
			cargoCarried = 0;

			int randomIndex = tradingPostDestinationIndex;
			while (randomIndex == tradingPostDestinationIndex) {
				randomIndex =  (int)Random.Range(0.0f, tradingPostList.Capacity);
			}
			tradingPostDestinationIndex = randomIndex;
		}
	}
}
