using UnityEngine;
using System.Collections;

public class GateStateHandler : MonoBehaviour {
	public float distanceTravelled = 0.0f;
	public float cargoCarried = 0.0f;
	public float cargoDelivered = 0.0f;
	public Transform tradingPostList;
	public Transform tradingPostDestinationList;

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
		if (other == tradingPostList){
			cargoDelivered += cargoCarried;
			cargoCarried = 0;
		}
	}
}

