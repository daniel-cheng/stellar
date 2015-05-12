using UnityEngine;
using System.Collections;

// This code has not been tested yet, and may contain bugs

public class BulletBehavior : MonoBehaviour {
    public Transform explosion;
    public StatSystem shooter;
	public float bulletDamage = 16.0f; // Sets damage to arbitrary value

	void OnTriggerEnter(Collider collider)
	{
        GameObject objectHit = collider.gameObject; // Gets the GameObject of the collider the bullet collided with
        StatSystem target = objectHit.GetComponent<StatSystem>();
        if (target != null && target != shooter) // Checks if the GameOject has a HealthHandler (to be implemented)
		{
            float targetHealth = target.ModifyHealth(bulletDamage); // HealthHandler.ModifyHealth(float damage) needs to be implemented
            Transform newExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as Transform;
            Debug.Log(shooter);
            if (target.isPlayer && shooter.isPlayer && targetHealth < 0)
            {
                shooter.kills += 1;
            }
            Destroy(newExplosion.gameObject, 4.0f);
        }
        //Destroy(gameObject);
	}
}
