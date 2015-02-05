using UnityEngine;
using System.Collections.Generic;

public class TurretAim : MonoBehaviour {

	//object that will be moving
	public Transform turret;
	//object that will be aimed at
	public Transform fighter;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		turret.transform.LookAt(fighter.position + fighter.rigidbody.velocity);
		}
}
