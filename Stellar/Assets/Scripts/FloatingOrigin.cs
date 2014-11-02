//Attempts to mitigate floating point errors by centering and zeroing velocities relative to the focus by applying them to other objects in the scene.

using UnityEngine;
using System.Collections;

public class FloatingOrigin : MonoBehaviour {
	public Vector3 origin = new Vector3(0, 0, 0);
	public Vector3 frameVelocity = new Vector3(0, 0, 0);
	public Transform focus;
	
	// Use this for initialization
	void Start () {
        Debug.Log(focus.rigidbody.velocity);
	}

    void FixedUpdate()
    {
        Vector3 offset = focus.position;
		frameVelocity -= focus.rigidbody.velocity;
		foreach (Transform topLevelObjects in transform.root){
			topLevelObjects.position -= offset;
		}
        Debug.Log(focus.rigidbody.velocity);
		origin += offset;
	}
}
