using UnityEngine;
using System.Collections;

public class GunnerAim : MonoBehaviour {
	
	public bool isEnabled = true;
	public Transform baseObject;
	public Transform guns; 
	
	public float xSpeed = 250.0f;
    public float ySpeed = 250.0f;

	private Vector3 oldMousePosition;
	private Vector3 deltaMousePosition;

    private float x = 0.0f;
    private float y = 0.0f;
    public float xMinLimit = -0;
    public float xMaxLimit = 0;
    public float yMinLimit = -0;
    public float yMaxLimit = 0;
	// Use this for initialization
	void Start () {
		oldMousePosition = Input.mousePosition;
		deltaMousePosition = Vector3.zero;

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
            guns.Rotate(Vector3.left * Time.deltaTime, y);
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
