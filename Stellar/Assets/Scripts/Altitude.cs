using UnityEngine;
using System.Collections.Generic;

public class Altitude : MonoBehaviour {
	public Transform planet;
	public float earthRadius = 10000.0f;
    public Transform focus;
	
	private float ratio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ratio = Mathf.Pow((focus.position - planet.position).magnitude / earthRadius, 2.0f);
	}
}
