using UnityEngine;
using System.Collections.Generic;

public class Hitmarker : MonoBehaviour{

    public List<Transform> turretList;

    public Transform arrow;

    public bool isEnabled;

    void Start()
    {
        SceneState.OnStateChange += OnStateChange;
        CameraState.OnStateChange += OnStateChange;
        GameStateHandler.OnTriggerStateChange += OnTriggerStateChange;

        Transform turretParent = GameObject.Find("Turret").transform;
        foreach (Transform turret in turretParent)
        {
            if (turret.parent == turretParent)
            {
                tradingList.Add(turret);
            }
        }
        
    }

 
    void Update()
    {
        //I need to look for the closest one here, right? 
        if (isEnabled)
        {
            Transform closestTurret = turretList[0];
            for (int x = 1; x < turretList.Length; x++)
            {
                //need help here. not sure how to measure distance
                if (Vector3.Distance(/*the freighter?*/, turretList[x]) < Vector3.Distance(/*the freighter?*/, closestTurret)){
                    closestTurret = turretList[x];
                }
            }
            arrow.LookAt(closestTurret);
        }
    }
}


