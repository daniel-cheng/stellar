using UnityEngine;
using System.Collections;

public class GameStateHandler : MonoBehaviour {
	public GameObject[] gateList;

	public float timeSinceStart = 0.0f;
	public int gatesPassed = 0;

	// Use this for initialization
	void Start () {
		gateList = GameObject.FindGameObjectsWithTag ("Gate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
