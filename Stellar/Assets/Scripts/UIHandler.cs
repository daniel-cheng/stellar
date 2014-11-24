using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {
	
	public GUIText debug;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetText(string text) {
		debug.text = text;
	}
}