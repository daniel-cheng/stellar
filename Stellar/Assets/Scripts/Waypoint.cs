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

    public List<Transform> tradingPosts;
    public List<Transform> gates;

	// Use this for initialization
	void Start () {
        SceneState.OnStateChange += OnStateChange;
        CameraState.OnStateChange += OnStateChange;
        GameStateHandler.OnTriggerStateChange += OnTriggerStateChange;

        Transform tradingPostsParent = GameObject.Find("Trading Posts").transform;
        foreach (Transform tradingPost in tradingPostsParent)
        {
            if (tradingPost.parent == tradingPostsParent)
            {
                tradingPosts.Add(tradingPost);
            }    
        }
        Transform gatesParent = GameObject.Find("Gates").transform;
        foreach (Transform gate in gatesParent)
        {
            if (gate.parent == gatesParent)
            {
                gates.Add(gate);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isEnabled)
        {
            Debug.Log(waypoints[waypointIndex].ToString());
            arrow.LookAt(waypoints[waypointIndex]);
        };
	}

    void OnTriggerStateChange()
    {
		waypointIndex += 1;
		if (waypointIndex >= waypoints.Capacity) {
			waypointIndex = 0;
		};

    }

    void OnStateChange()
    {
        if (SceneState.sceneIndex == 1)
        {
            waypoints = gates;
        }
        else if (SceneState.sceneIndex == 2)
        {
            waypoints = gates;
        }
    }
}
