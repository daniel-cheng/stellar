using UnityEngine;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour {

	//transforms the arrow will be pointing at
	public List<Transform> waypoints;
	//current index of transform the arrow should be pointing at
	public int waypointIndex = 0;
	//object that will be pointed at
	public Transform arrow;
	//toggles whether or not arrow is visible
	public bool isEnabled;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isEnabled)
        {
            Debug.Log(waypoints[waypointIndex].ToString());
            arrow.LookAt(waypoints[waypointIndex]);
        };
	}
}
