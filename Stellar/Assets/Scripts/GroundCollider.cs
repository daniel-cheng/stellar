using UnityEngine;
using System.Collections;

public class GroundCollider : MonoBehaviour {
	public Transform trackedObject;
	public Transform planet;
	public float planetRadius = 10000.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = (trackedObject.position - planet.position).normalized;
		transform.LookAt(trackedObject);
	}
}
