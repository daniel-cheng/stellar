using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
    public static GameObject player;
    public bool offline = true;
    public GameObject offlinePlayer;

    // Use this for initialization

    void Awake()
    {
        player = offlinePlayer;
    }

    void Start () {
        if (offline == false)
        {
            PhotonNetwork.ConnectUsingSettings("0.1");
        }
        else
        {
            player = (GameObject)Instantiate(offlinePlayer, Vector3.zero, Quaternion.identity);
            player.transform.parent = this.transform;
            this.GetComponent<EventNotifier>().OnNetwork();
        }
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
    }

	void OnJoinedRoom()
	{
		player = PhotonNetwork.Instantiate("prefabFighter", Vector3.zero, Quaternion.identity, 0);
        player.GetComponent<Fly>().isEnabled = true;
        Debug.Log(player.GetComponent<Fly>().isEnabled);
        player.transform.parent = this.transform;
        this.GetComponent<EventNotifier>().OnNetwork();
        Debug.Log("Hello41241");
	}
}
