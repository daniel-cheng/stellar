using UnityEngine;
using System.Collections;

public class StatSystem : MonoBehaviour {

	public float health;
    public GameObject root;

	public void ModifyHealth(float damage)
	{
        
		health -= damage;
        Debug.Log(health);
        if (health < 0)
        {
            Destroy(root);
        }
	}
}
