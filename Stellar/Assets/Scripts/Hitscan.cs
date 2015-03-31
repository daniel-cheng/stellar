using UnityEngine;
using System.Collections;

public class Hitscan : MonoBehaviour {
	public LineRenderer lineRendererTrail;
	public Transform explosion;
	public float range = 100;
	public Transform rootObject;

	private float capacitorCharge = 0;
	private AudioSource myAudio;
	private ParticleSystem myParticleSystem;
	private bool loaded = true;
	private bool roundShot = false;
	// Use this for initialization
	void Start () {
		myAudio = rootObject.GetComponentInChildren<AudioSource>() as AudioSource;
		myParticleSystem = rootObject.GetComponentInChildren<ParticleSystem>() as ParticleSystem;
		myParticleSystem.emissionRate = 50;
		foreach (Collider firstCollider in rootObject.GetComponentsInChildren<Collider>() as Collider[]) {
			foreach (Collider secondCollider in rootObject.GetComponentsInChildren<Collider>() as Collider[]) {
				if (firstCollider != secondCollider) {
					Physics.IgnoreCollision(firstCollider, secondCollider);
//					Debug.Log (firstCollider.ToString() + " ignores collisions with " + secondCollider.ToString());
				}
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Fire1")) {
			if (!roundShot) {
				myAudio.Stop();
			}
			Debug.Log (myParticleSystem.enableEmission);
			myParticleSystem.enableEmission = true;
			capacitorCharge = 0;
			myParticleSystem.emissionRate = 50;
			loaded = true;
			roundShot = false;
		}
		if (Input.GetButton("Fire1")) {
			if ((capacitorCharge < 3000)&&(loaded == true)) { 
				capacitorCharge = capacitorCharge + 1000 * Time.deltaTime;
				myParticleSystem.emissionRate = capacitorCharge / 10;
			} else if ((capacitorCharge >= 3000)&&(loaded == true)) {
				Vector3 relativeForward = Vector3.Normalize(transform.localToWorldMatrix * Vector3.up);
				//Transform newObjectInstance = Instantiate(newObject, (transform.position + transform.rotation * offset), transform.rotation) as Transform;
				//newObjectInstance.rigidbody.AddForce(relativeForward * capacitorCharge * velocity);
				//Physics.IgnoreCollision(newObjectInstance.collider, collider);
				RaycastHit hit;
				float distanceToImpact = range;
        		if (Physics.Raycast(transform.position, relativeForward, out hit, range)) {
            		distanceToImpact = hit.distance;
				}
				LineRenderer lineRendererTrailObject = (LineRenderer)Instantiate(lineRendererTrail, Vector3.zero, Quaternion.identity);
				lineRendererTrailObject.SetPosition(0, transform.position);
				lineRendererTrailObject.SetPosition(1, relativeForward * distanceToImpact);
				Debug.Log ("distanceToImpact = " + distanceToImpact + " hit.point = " + hit.point);
				Instantiate(explosion, relativeForward * distanceToImpact, Quaternion.identity);
				
				foreach (Rigidbody child in rootObject.GetComponentsInChildren<Rigidbody>() as Rigidbody[]) {
					child.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.up, ForceMode.VelocityChange);	
				}
				capacitorCharge = 0;
				myParticleSystem.emissionRate = 0;
				loaded = false;
				roundShot = true;
			} else {
				myParticleSystem.emissionRate = 0;
			}
		}
		if (Input.GetButtonDown("Fire1")) {
			myAudio.Play();
		}
	}
}
