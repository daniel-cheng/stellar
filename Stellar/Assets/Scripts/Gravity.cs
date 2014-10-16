using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public Transform planet;
	public float magnitude = 9.8f;
	public float gravitationalParameter = 3.9860044189f * Mathf.Pow(10.0f, 7.0f);

	private Vector3 instantaneousAcceleration = new Vector3(0.0f, 0.0f, 0.0f);
	private Vector3 earthDirection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {	
		earthDirection = transform.position - planet.position;
		Debug.DrawRay(transform.position, -earthDirection);
		Debug.Log ((-gravitationalParameter / earthDirection.sqrMagnitude).ToString());
		rigidbody.AddForce((-gravitationalParameter / earthDirection.sqrMagnitude) * earthDirection.normalized, ForceMode.VelocityChange);
	}
}
