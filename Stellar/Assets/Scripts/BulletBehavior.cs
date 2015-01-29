using UnityEngine;
using System.Collections;

// This code has not been tested yet, and may contain bugs

public class BulletBehavior : MonoBehaviour {
	private float bulletDamage = 8.0f; // Sets damage to arbitrary value

	void OnCollisionEnter(Collision collision)
	{
		GameObject objectHit = collision.gameObject; // Gets the GameObject of the collider the bullet collided with
		//if (objectHit.GetComponent<HealthHandler>() != null) // Checks if the GameOject has a HealthHandler (to be implemented)
		{
			//objectHit.GetComponent<HealthHandler>().ModifyHealth(bulletDamage); // HealthHandler.ModifyHealth(float damage) needs to be implemented
		}
	}
}
