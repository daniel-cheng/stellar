using UnityEngine;
using System.Collections;

/// <summary>
/// Applies gravitational force to all rigidbodies, with exception to those on the noGravity list.
/// </summary>

public class Gravity : MonoBehaviour {
	public Transform planet;
	public float magnitude = 9.8f;

	private float gravitationalParameter = 3.9860044189f * Mathf.Pow(10.0f, 7.0f);
	private Vector3 planetDirection;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        planetDirection = -Vector3.Normalize(transform.position - planet.position);
        Physics.gravity = planetDirection * magnitude;
	}
}
