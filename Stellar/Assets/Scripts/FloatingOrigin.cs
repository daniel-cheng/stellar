//Attempts to mitigate floating point errors by centering and zeroing velocities relative to the focus by applying them to other objects in the scene.

using UnityEngine;
using System.Collections;

public class FloatingOrigin : MonoBehaviour {
	public Vector3 origin = new Vector3(0, 0, 0);
	public Vector3 frameVelocity = new Vector3(0, 0, 0);
	public Transform focus;
	public float updateInterval = 0.1f;
	
	// Use this for initialization
	void Start () {
		//camera.nearClipPlane = 0.0001f;
	}
	
	// Update is called once per frame
	void OnPostRender () {
		Vector3 offset = Camera.main.transform.localPosition;
		frameVelocity -= focus.rigidbody.velocity;
		foreach (Transform topLevelObjects in transform.root){
			if (topLevelObjects.rigidbody && focus != topLevelObjects){
				topLevelObjects.rigidbody.velocity -= focus.rigidbody.velocity;
			}
			topLevelObjects.position -= offset;
		}
		focus.rigidbody.velocity = Vector3.zero;
		origin += offset;
	}
}
