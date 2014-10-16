using UnityEngine;
using System.Collections;
using System.IO;

public class PositionDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Projector>().fieldOfView = 0;
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.BackQuote)) {
			GetComponentInChildren<Projector>().fieldOfView = 1;
		}
		if (Input.GetKeyUp(KeyCode.BackQuote)) {
			GetComponentInChildren<Projector>().fieldOfView = 0;
		}
		if (Input.GetKey(KeyCode.BackQuote) && Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log(hit.point.ToString());
				StreamWriter sw = new StreamWriter("Fallingwater Configuration.txt", true);
				sw.WriteLine("Position New = " + hit.point.ToString("F3"));
				sw.Close();
			}
		}
	}
}
