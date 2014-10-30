using UnityEngine;
using System.Collections;

/// <summary>
/// Gravity alters the direction of Unity's graviy vector to the 
/// correct direction and magnitude with respect to the central planet.
/// </summary>

public class Gravity : MonoBehaviour {
	public Transform planet;
<<<<<<< HEAD
	public float magnitude = 9.8f;
	public float planetDistance2;
=======
    public float gravitationalParameter = 3986004418.9f;
>>>>>>> origin/master

	private Vector3 planetDirection;
    private float planetDistanceSquared;

	// Use this for initialization
	void Start () {
	}
	
	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
<<<<<<< HEAD

		planetDistance2 = (transform.position - planet.position).sqrMagnitude;
        planetDirection = -Vector3.Normalize(transform.position - planet.position);
		Physics.gravity = (planetDirection * magnitude)/planetDistance2;

=======
        planetDistanceSquared = Vector3.SqrMagnitude(transform.position - planet.position);
        planetDirection = -Vector3.Normalize(transform.position - planet.position);
        Physics.gravity = planetDirection * gravitationalParameter / planetDistanceSquared;
        
>>>>>>> origin/master
	}
}
