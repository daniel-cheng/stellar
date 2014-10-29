using UnityEngine;
using System.Collections;

/// <summary>
/// Gravity alters the direction of Unity's graviy vector to the 
/// correct direction and magnitude with respect to the central planet.
/// </summary>

public class Gravity : MonoBehaviour {
	public Transform planet;
    public float gravitationalParameter = 3986004418.9f;

	private Vector3 planetDirection;
    private float planetDistanceSquared;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        planetDistanceSquared = Vector3.SqrMagnitude(transform.position - planet.position);
        planetDirection = -Vector3.Normalize(transform.position - planet.position);
        Physics.gravity = planetDirection * gravitationalParameter / planetDistanceSquared;
        
	}
}
