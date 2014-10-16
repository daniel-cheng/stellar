// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	public Transform explosion;
	
	void  Start () {
	
	}
	
	void  Update () {
	
	}
	
	void  OnCollisionEnter (){
		Instantiate(explosion, transform.position, transform.rotation);
//		Debug.Log("Explosion created");
		Destroy(gameObject);
	}
	void  OnCollisionExit (){
		Instantiate(explosion, transform.position, transform.rotation);
//		Debug.Log("Explosion created");
		Destroy(gameObject);
	}
	void  OnCollisionStay (){
		Instantiate(explosion, transform.position, transform.rotation);
//		Debug.Log("Explosion created");
		Destroy(gameObject);
	}
}