using UnityEngine;
using System.Collections;

public class Altitude : MonoBehaviour {
	public Camera farCamera;
	public Transform planet;
	public float earthRadius = 10000.0f;
	public Vector2 initialClippingBounds = new Vector2(1.0f, 100000.0f);
	
	private float ratio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ratio = Mathf.Pow((farCamera.transform.position - planet.position).magnitude / earthRadius, 2.0f);
		farCamera.nearClipPlane = initialClippingBounds.x * ratio;
		farCamera.farClipPlane = initialClippingBounds.y * ratio;
	}
}
