using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour {
	public Transform currentObject;
	// Use this for initialization
	void Start () {
		if (!currentObject) {
			currentObject = transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 relativeForward = Vector3.Normalize(transform.localToWorldMatrix * Vector3.up);
		RaycastHit hit;
		if (Physics.Raycast(currentObject.position, relativeForward, out hit, 100.0F)) {
			float distanceToImpact = hit.distance;
			Debug.Log(hit.point);
		} else {
			Debug.Log(relativeForward * 100 + currentObject.position);
		}
	}
}
