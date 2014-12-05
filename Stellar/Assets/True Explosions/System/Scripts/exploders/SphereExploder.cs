using UnityEngine;
using System.Collections;

public class SphereExploder : Exploder {
	public override IEnumerator explode() 
	{
		exploded = true;
		
		ExploderComponent[] components = GetComponents<ExploderComponent>();
		foreach (ExploderComponent component in components) {
			component.onExplosionStarted(this);
		}


		while (explodeDuration > Time.time - explosionTime) {
			collider.isTrigger = true;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) {
				if (hit && hit.rigidbody) {
					hit.rigidbody.AddExplosionForce(power * Time.deltaTime, explosionPos, radius);
				} else if (hit.collider.gameObject.name == "MainCamera") {
					Vector3 dPos = Random.onUnitSphere * 0.01f;
					hit.transform.position = hit.transform.position + dPos;
				}
				
			}
			collider.isTrigger = false;
			yield return new WaitForEndOfFrame();
		}
	}

	void Start() {
		power *= 200;
		
		if (randomizeExplosionTime > 0.01f) {
			explosionTime += Random.Range(0.0f, randomizeExplosionTime);
		}
	}

	void FixedUpdate () {
		if (Time.time > explosionTime && !exploded) {
			StartCoroutine("explode");
		}
	}
}
