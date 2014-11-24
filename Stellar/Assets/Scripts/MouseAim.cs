using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {

	public bool isEnabled;

	private float deltaX;
	private float deltaY;
	private float angleX;
	private float angleY;
	private float turnRateX;
	private float turnRateY;
	private Vector3 rateOfTurn = Vector3.zero;

	// Use this for initialization
	void Start () {
        SceneState.OnStateChange += OnStateChange;
        CameraState.OnStateChange += OnStateChange;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isEnabled) 
		{
			/**/deltaX = Input.mousePosition.x - Screen.width/2;
			deltaY = Input.mousePosition.y - Screen.height/2;

			deltaX /= (Screen.width / 2);
			deltaY /= (Screen.height / 2);

			angleX = Mathf.Rad2Deg * Mathf.Asin (deltaX) * 4.0f;
			angleY = Mathf.Rad2Deg * Mathf.Asin (deltaY)  * 4.0f;
			
			/*angleX = Mathf.Rad2Deg * Mathf.Asin (deltaX);
			angleY = Mathf.Rad2Deg * Mathf.Asin (deltaY);*/

			turnRateX = angleX/90.0f;
			turnRateY = angleY/90.0f;

            if (!float.IsNaN(angleX) && !float.IsNaN(angleY))
            {
				rateOfTurn = transform.eulerAngles + new Vector3(-turnRateY, turnRateX, 0.0f);
				transform.eulerAngles = rateOfTurn;
				//transform.Rotate(new Vector3(-angleY, angleX, 0.0f));
            }

			/*float distanceZ = (transform.position.z - Camera.main.transform.position.z)*1.0f;
			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceZ);
			position = Camera.main.ScreenToWorldPoint(position);
			transform.LookAt (position);*/
		}
	}

    void OnStateChange()
    {
        if (SceneState.sceneIndex == 1)
        {
            if (CameraState.stateIndex == 1)
            {
                enabled = false;
            }
            else
            {
                enabled = true;
            }
        }
        else
        {
            enabled = false;
        }
    }
}
