using UnityEngine;
using System.Collections;

public class GameStateHandler : MonoBehaviour {
	public GameObject[] gateList;
	public ArrayList gateList;

	// Use this for initialization
	void Start () {
		gateList = GameObject.FindGameObjectsWithTag ("Gate");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
