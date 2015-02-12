using UnityEngine;
using System.Collections;

public class StatSystem : MonoBehaviour {

	public float health;

	public void ModifyHealth(float damage)
	{
        
		health -= damage;
        if (health < 0)
        {
            //Destroy(gameObject);
        }
	}
}
