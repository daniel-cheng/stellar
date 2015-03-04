using UnityEngine;
using System.Collections.Generic;

public class Autogunner : MonoBehaviour {
    public bool isEnabled;
    public float velocity = 100;
    public Transform newObject;
    public Transform rootObject;
	public Transform railgunObject;
	public Transform fighter;
    public float offset = 10.0f;
	public float maxRange = 5000.0f;
    public float rateOfFire = 0.2f;
    public float reloadTimer = 0.0f;
	
	// Update is called once per frame
	void Update () {
        if (isEnabled && reloadTimer < rateOfFire && (Vector3.Distance(fighter.position, railgunObject.position) <= maxRange))
        {
            Transform clone = Instantiate(newObject, rootObject.position + rootObject.up * offset, rootObject.rotation) as Transform;
            clone.transform.parent = transform.root;
            clone.rigidbody.velocity = clone.up * velocity;
            Physics.IgnoreCollision(clone.collider, railgunObject.collider);
            Destroy(clone.gameObject, 5.0f);
            reloadTimer = 0.0f;
        }
        reloadTimer = Time.deltaTime;
	}
}
