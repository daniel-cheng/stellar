using UnityEngine;
using System.Collections;

public class StatSystem : MonoBehaviour {

	public float health;

	void ModifyHealth(float damage)
	{
		health -= damage;
	}
}
