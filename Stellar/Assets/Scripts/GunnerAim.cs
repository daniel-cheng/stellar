using UnityEngine;
using System.Collections;

public class GunnerAim : MonoBehaviour {
	
	public bool isEnabled = true;
	public Transform baseObject;
	public Transform Guns; 
	
	public float xSpeed = 250.0f;
    public float ySpeed = 250.0f;



	private Vector3 oldMousePosition;
	private Vector3 deltaMousePosition;
	private Transform bottomArmsObject;
	private Transform topArmsObject;
	private Transform casingObject;
	private Transform barrelObject;
	
    private float x = 0.0f;
    private float y = 0.0f;
	private float xMinLimit = -90;
	private float xMaxLimit = 90;
	private float yMinLimit = -90;
	private float yMaxLimit = 90;
	// Use this for initialization
	void Start () {
		oldMousePosition = Input.mousePosition;
		deltaMousePosition = Vector3.zero;
		bottomArmsObject = baseObject.Find("bottom_arms").transform;

		var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnabled) {
			x = Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
			y = Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
  
					
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			x = ClampAngle(x, xMinLimit, xMaxLimit); 
			baseObject.Rotate(Vector3.up * Time.deltaTime, x);
			Guns.Rotate(Vector3.right * Time.deltaTime, y);
//			bottomArmsObject.rotation = Quaternion.Euler(y, x, 0);


			//baseObject.rigidbody.AddRelativeTorque(
//			baseObject.rigidbody.AddRelativeTorque(new Vector3(0, x, 0), ForceMode.VelocityChange);
//			bottomArmsObject.rigidbody.AddRelativeTorque(new Vector3(y, 0, 0), ForceMode.VelocityChange);
		}
	}
	
	static float ClampAngle(float angle, float min, float max) {
            if (angle < -360) {
                angle += 360;
            }
            if (angle > 360) {
                angle -= 360;
            }
            return Mathf.Clamp(angle, min, max);
        }
	
}
