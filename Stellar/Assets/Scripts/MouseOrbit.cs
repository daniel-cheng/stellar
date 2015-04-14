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
	private float slerpTime = 0.0f;
	private float slerpPeriod = 1.0f;
	private Quaternion storedRotation;

	void Start () 
	{
	    var angles = transform.eulerAngles;
	    x = angles.y;
	    y = angles.x;

		storedRotation = new Quaternion();

	    // Make the rigid body not change rotation
	    if (GetComponent<Rigidbody>()) 
	        GetComponent<Rigidbody>().freezeRotation = true;
	}

	void Update () {
    	if (isEnabled && target) {
			if (Input.GetKey(KeyCode.C)){
				storedRotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
				transform.localRotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
				//x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
				//y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
				//y = Mathf.Clamp(y % 360.0f, yMinLimit, yMaxLimit);
				zoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 50.0f * zoom;
				transform.position = storedRotation * new Vector3(0.0f, 0.0f, -distance * zoom) + target.position;
			}

			slerpTime = 0.0f;
		} else if (slerpTime < slerpPeriod) {
			slerpTime += Time.deltaTime;
			x = Mathf.Clamp01(x * (1.0f - slerpTime));
			y = Mathf.Clamp01(y * (1.0f - slerpTime));
		}
	}
}