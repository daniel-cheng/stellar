using UnityEngine;
using System.Collections.Generic;

public class Autogunner : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<ShootRound>().Shoot();
	}
}
