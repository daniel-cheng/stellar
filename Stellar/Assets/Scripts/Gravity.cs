using UnityEngine;
using System.Collections;

/// <summary>
/// Applies gravitational force to all rigidbodies, with exception to those on the noGravity list.
/// </summary>

public class Gravity : MonoBehaviour {
	public Transform planet;
    public ArrayList noGravity;
	public float magnitude = 9.8f;

	private float gravitationalParameter = 3.9860044189f * Mathf.Pow(10.0f, 7.0f);
	private Vector3 planetDirection;
    private ArrayList useGravity;

	// Use this for initialization
	void Start () {
        //search through entire hierarchy for top level rigidbodies, and store them in useGravity.
	}
	
	// Update is called once per frame
	void Update () {
        //for each transform in useGravity...
        planetDirection = Vector3.Normalize(transform.position - planet.position);
        rigidbody.velocity = rigidbody.velocity - planetDirection * magnitude * Time.deltaTime;
	}
}
