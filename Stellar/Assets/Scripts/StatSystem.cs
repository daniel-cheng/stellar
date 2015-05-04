using UnityEngine;
using System.Collections;

public class StatSystem : Photon.MonoBehaviour {

	public float health;
    public float initalHealth = 100.0f;
    public int kills;
    public int deaths;
    public float killDeathRatio;
    public GameObject root;
    public bool isPlayer = false;

    private Quaternion targetRotation = new Quaternion();
    private Vector3 targetPosition = new Vector3();

    void Start()
    {
        if (!root)
        {
            root = gameObject;
        }
    }

    void Update()
    {
        if (isPlayer && !photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);
        }

        if (health < 0)
        {
            deaths += 1;
            if (isPlayer)
            {
                updateKillDeathRatio();
                root.transform.position = Vector3.zero;
                root.transform.rotation = Quaternion.identity;
                health = initalHealth;
            }
            else
            {
                Destroy(root);
            }
        }
    }

	public void ModifyHealth(float damage)
	{
        
		health -= damage;
        Debug.Log(health);
        
	}

    public void updateKillDeathRatio()
    {
        if (deaths > 0)
        {
            killDeathRatio = kills / deaths;
        }
    }


    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(health);
        }
        else
        {
            // Network player, receive data
            this.targetPosition = (Vector3)stream.ReceiveNext();
            this.targetRotation = (Quaternion)stream.ReceiveNext();
            this.health = (float)stream.ReceiveNext();
        }
    }
}
