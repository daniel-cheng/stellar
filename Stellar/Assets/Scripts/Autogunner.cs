using UnityEngine;
using System.Collections.Generic;

public class Autogunner : MonoBehaviour {
    public bool isEnabled;
    public float velocity = 100;
    public Transform newObject;
    public Transform rootObject;
    public float offset = 10.0f;
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (isEnabled)
        {
            Transform clone = Instantiate(newObject, rootObject.position + rootObject.up * offset, rootObject.rotation) as Transform;
            clone.transform.parent = transform.root;
            clone.rigidbody.velocity = clone.up * velocity;
            //			Physics.IgnoreCollision(clone.collider, collider);
            Destroy(clone.gameObject, 5.0f);
        }
	}
}
