// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	public float translationalSpeed = 1000.0f;
	public float rotationTorque = 1000.0f;
	public float thrust = 100.0f;
	public bool  sas = false;
	public float sasForce = 100;
	public Vector2 engineLifetimeBounds = new Vector2(0.0f, 0.8f);
	public Vector2 engineSizeBounds = new Vector2(1.2f, 1.85f);
	public Vector2 exhaustLifetimeBounds = new Vector2(0.0f, 4.0f);
	public Vector2 exhaustSizeBounds = new Vector2(1.2f, 6.0f);
	public Vector2 exhaustEmissionBounds = new Vector2(0.0f, 50.0f);
	public float scaleHeight = 16.6f;
	public float earthRadius = 10000.0f;
	public Transform earth;
	public float seaLevelDensity = 1.0f;
    public float throttleSpeed = 50.0f;
	
	private ArrayList engineList;
	private ArrayList exhaustList;
	private ArrayList audioSourceList;
	private float throttle;
	private Animator animator;
	private bool gearDown;
	private float earthDistance;
	private float earthAltitude;
	private float atmosphericDensity;

	
	void  Start () {
		Component[] particleSystemComponents = GetComponentsInChildren<ParticleSystem>();
		Component[] audioSourceComponents = GetComponentsInChildren<AudioSource>();
		engineList = new ArrayList();
		exhaustList = new ArrayList();
		audioSourceList = new ArrayList();
		foreach (ParticleSystem child in particleSystemComponents){
			if (child.name.Contains("Engine")){
				engineList.Add(child);
			} else if (child.name.Contains("Exhaust")){
				exhaustList.Add(child);
			}
		}
		foreach (AudioSource child in audioSourceComponents){
			if (child.transform.parent == transform){
				audioSourceList.Add(child);
				child.audio.volume = 0;
			}
		}
		animator = GetComponent<Animator>();
		gearDown = false;
	}
	//rotational : x ws y qe z ad
	//translational : x hn y ik z jl
	
	void  Update (){  
	
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float angularX = Input.GetAxis ("AngularX") * rotationTorque * Time.deltaTime;
		float angularY = Input.GetAxis ("AngularY") * rotationTorque * Time.deltaTime;
		float angularZ = -1 * Input.GetAxis ("AngularZ") * rotationTorque * Time.deltaTime;
		float linearX = Input.GetAxis ("LinearX") * translationalSpeed * Time.deltaTime;
		float linearY = Input.GetAxis ("LinearY") * translationalSpeed * Time.deltaTime;
		float linearZ = Input.GetAxis ("LinearZ") * translationalSpeed * Time.deltaTime;
        throttle = throttle + Input.GetAxis("Throttle") * Time.deltaTime * throttleSpeed;
		throttle = Mathf.Clamp(throttle, 0.0f, 10.0f);
		
		Vector3 relativeForward = transform.TransformDirection (Vector3.forward);
		Vector3 angularTorqueVector = new Vector3(angularX, angularY, angularZ);
		
		rigidbody.AddForce (relativeForward * throttle * thrust / 10);
		rigidbody.AddTorque(transform.rotation * angularTorqueVector);
		rigidbody.AddForce(linearX, linearY, linearZ ); //Space.World = Translate in world space - local space is default

        transform.position += new Vector3(linearX, linearY, linearZ);

		earthDistance = (transform.position - earth.position).magnitude;
		earthAltitude = earthDistance - earthRadius;
		atmosphericDensity = Mathf.Exp(-earthAltitude / scaleHeight);

		if (sas == true && angularX == 0.0f && angularY == 0.0f && angularZ == 0.0f) {
			rigidbody.AddTorque(-sasForce*rigidbody.angularVelocity.x, -sasForce*rigidbody.angularVelocity.y, -sasForce*rigidbody.angularVelocity.z);
		}
		foreach(ParticleSystem child in engineList) {
			if (throttle != 0.0){
				child.particleSystem.enableEmission = true;
				child.particleSystem.startLifetime = Mathf.Lerp(engineLifetimeBounds.x, engineLifetimeBounds.y, throttle / 10.0f);
				child.particleSystem.startSize = Mathf.Lerp(engineSizeBounds.x, engineSizeBounds.y, throttle / 10.0f);
			} else {
				child.particleSystem.enableEmission = false;
			}
		}
		foreach(ParticleSystem child in exhaustList) {
			if (throttle != 0.0){
				child.particleSystem.enableEmission = true;
				child.particleSystem.startLifetime = Mathf.Lerp(exhaustLifetimeBounds.x, exhaustLifetimeBounds.y, throttle / 10.0f);
				child.particleSystem.startSize = Mathf.Lerp(exhaustSizeBounds.x, exhaustSizeBounds.y, throttle / 10.0f);
				child.particleSystem.emissionRate = Mathf.Lerp(exhaustEmissionBounds.x, exhaustEmissionBounds.y, atmosphericDensity); 
			} else {
				child.particleSystem.enableEmission = false;
			}
		}
		foreach(AudioSource child in audioSourceList) {
			child.audio.volume = throttle / 10.0f * atmosphericDensity;
		}
		if (Input.GetKeyDown(KeyCode.T)) {
			sas = !sas;
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			sas = !sas;
		}
		if (Input.GetKeyUp(KeyCode.F)) {
			sas = !sas;
		}
		if (Input.GetKeyUp(KeyCode.G)) {
			gearDown = !gearDown;
			if (animator){
				animator.SetBool ("GearDown", gearDown);
			}
		}

	}
}