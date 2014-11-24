using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {
	public Transform target; 
	public float distance = 10.0f;
	public bool isEnabled = true;
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -20;
	public float yMaxLimit = 80;

	private float x = 0.0f;
	private float y = 0.0f;
	private float zoom = 1.0f;

	void Start () 
	{
	    var angles = transform.eulerAngles;
	    x = angles.y;
	    y = angles.x;

	    // Make the rigid body not change rotation
	    if (rigidbody) 
	        rigidbody.freezeRotation = true;
	}

	void Update () {
	    	if (isEnabled && target) {
				if (Input.GetMouseButton(0)){
					x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
					y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
					y = Mathf.Clamp(y % 360.0f, yMinLimit, yMaxLimit);
				}
				zoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 50.0f * zoom;
				transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance * zoom) + target.position;
                transform.LookAt(target);
	        }
	}
}