using UnityEngine;
using System.Collections;

public class StatSystem : MonoBehaviour {

	public float health;
    public GameObject root;
	public int kills;
	public int deaths;
	public UIHandler uiHandler;

	public void ModifyHealth(float damage)
	{
        
		health -= damage;
        Debug.Log(health);
        if (health < 0)
        {
			deaths+= 1;
            Destroy(root);
			//inactivate it
			//go display the deaths and kills onscreen

        }
	}
	void Start() {

		uiHandler = GameObject.Find ("Floating Origin").GetComponent<UIHandler> ();
	}
	void Update() {

		uiHandler.SetUpperRightText ("hello");
	}
}
