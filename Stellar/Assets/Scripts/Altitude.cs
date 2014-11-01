using UnityEngine;
using System.Collections.Generic;

public class Altitude : MonoBehaviour {
    public List<Camera> cameras;
	public Transform planet;
	public float earthRadius = 10000.0f;
	public List<Vector2> initialClippingBounds;
	
	private float ratio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < cameras.Capacity; i++)
        {
            ratio = Mathf.Pow((cameras[i].transform.position - planet.position).magnitude / earthRadius, 2.0f);
            cameras[i].nearClipPlane = initialClippingBounds[i].x * ratio;
            cameras[i].farClipPlane = initialClippingBounds[i].y * ratio;
        }
	}
}
