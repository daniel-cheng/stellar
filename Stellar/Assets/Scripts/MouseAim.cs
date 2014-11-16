using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {

	public bool isEnabled;

	private float deltaX;
	private float deltaY;
	private float angleX;
	private float angleY;
	private Vector3 faceDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		//if (isEnabled)
		//	Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isEnabled) 
		{
			Debug.Log("nput.mousePosition.x: " + Input.mousePosition.x);
			Debug.Log("nput.mousePosition.y: " + Input.mousePosition.y);

			deltaX = Input.mousePosition.x - Screen.width/2;
			deltaY = Input.mousePosition.y - Screen.height/2;

			deltaX /= (Screen.width / 2);
			deltaY /= (Screen.height / 2);

			angleX = Mathf.Rad2Deg * Mathf.Asin (deltaX);
			angleY = Mathf.Rad2Deg * Mathf.Asin (deltaY);


			transform.eulerAngles = new Vector3(-angleY, angleX, 0.0f);
		}
	}
}
