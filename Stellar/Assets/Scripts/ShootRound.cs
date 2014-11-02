// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.


// convert to raycast
// add bomb dropping and colony planting
using UnityEngine;
using System.Collections;

public class ShootRound : MonoBehaviour {


	public float velocity = 20;
	public Transform newObject;
	public Transform rootObject;
	private Vector3 offset;
	private float capacitorCharge = 0;
	private AudioSource myAudio;
	private ParticleSystem myParticleSystem;
	private MouseOrbit myCamera;
	private GunnerAim myGunnerAim;
	private bool loaded = true;
	private bool roundShot = false;


	void  Start (){
		//offset = new Vector3(0, 0f, 0f);
		myAudio = rootObject.GetComponentInChildren<AudioSource>() as AudioSource;
		myParticleSystem = rootObject.GetComponentInChildren<ParticleSystem>() as ParticleSystem;
		myCamera = rootObject.GetComponentInChildren<MouseOrbit>() as MouseOrbit;
		myGunnerAim =  rootObject.GetComponent<GunnerAim>() as GunnerAim;
		myParticleSystem.emissionRate = 10;
		foreach (Collider firstCollider in rootObject.GetComponentsInChildren<Collider>() as Collider[]) {
			foreach (Collider secondCollider in rootObject.GetComponentsInChildren<Collider>() as Collider[]) {
				if (firstCollider != secondCollider) {
					Physics.IgnoreCollision(firstCollider, secondCollider);
//					Debug.Log (firstCollider.ToString() + " ignores collisions with " + secondCollider.ToString());
				}
			}
			
		}
		
	}

	void  Update (){
//		if (Input.GetButtonUp("Fire1")) {
//			Vector3 relativeForward = transform.InverseTransformDirection (Vector3.forward);
//			RaycastHit hit;
//			Vector3 velocityVector = (velocity * relativeForward) + rigidbody.velocity;
//			if (Physics.Raycast(transform.TransformPoint(offset), relativeForward, out hit)) {
//				Instantiate(newObject, hit.point, transform.rotation);
//			}
//			newObjectInstance.rigidbody.AddForce(velocityVector * capacitorCharge);
//			Debug.Log("Round shot");
//			capacitorCharge = 0;
//		}
		if (Input.GetButtonUp("Fire1")) {
			if (!roundShot) {
				myAudio.Stop();
			}
			capacitorCharge = 0;
			myParticleSystem.emissionRate = 0;
			loaded = true;
			roundShot = false;
		}
		if (Input.GetButton("Fire1")) {
            Rigidbody clone;
            clone = Instantiate(newObject, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * velocity);
			Physics.IgnoreCollision(clone.collider, collider);
			Destroy(clone.gameObject, 1f);

	
		
//            if ((capacitorCharge < 3000)&&(loaded == true)) { 
//                capacitorCharge = capacitorCharge + 1000 * Time.deltaTime;
//                myParticleSystem.emissionRate = capacitorCharge / 10;
//            } else if ((capacitorCharge >= 3000)&&(loaded == true)) {
//                Vector3 relativeForward = transform.TransformDirection(-Vector3.forward); //current model is reversed, hence the -.
//                Transform newObjectInstance = Instantiate(newObject, (transform.position + transform.rotation * offset), transform.rotation) as Transform;
////				newObjectInstance.rigidbody.AddForce(relativeForward * capacitorCharge * velocity);
//                Physics.IgnoreCollision(newObjectInstance.collider, collider);
//                float chargePercentage = 1;
//                foreach (Rigidbody child in rootObject.GetComponentsInChildren<Rigidbody>() as Rigidbody[]) {
//                    child.rigidbody.AddRelativeForce(-Vector3.up * chargePercentage, ForceMode.VelocityChange);	
//                    chargePercentage = chargePercentage * 0.66f;
//                }
//                capacitorCharge = 0;
//                myParticleSystem.emissionRate = 0;
//                loaded = false;
//                roundShot = true;
//            } else {
//                myParticleSystem.emissionRate = 0;
//            }
		}
        //if (Input.GetButtonDown("Fire1")) {
        //    myAudio.Play();
        //}
	}
}