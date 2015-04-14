using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
    public static GameObject player;
    public bool offline = true;
    public GameObject offlinePlayer;
    public Transform earth;

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
        GameObject oldPlayer = player;
		player = PhotonNetwork.Instantiate("prefabFighter", Vector3.zero, Quaternion.identity, 0);
        Fly playerFly = player.GetComponent<Fly>();
        playerFly.earth = earth;
        playerFly.isEnabled = true;
        CameraState cameraState = GetComponent<CameraState>();
        cameraState.cameraObjectList[0] = player.transform.Find("Camera Cockpit").gameObject;
        cameraState.cameraObjectList[1] = player.transform.Find("turret/guns/Camera Gunner").gameObject;
        cameraState.cameraObjectList[2] = player.transform.Find("Camera Third Person Fighter").gameObject;
        player.transform.parent = this.transform;
        this.GetComponent<EventNotifier>().OnNetwork();
        Destroy(oldPlayer);
        Debug.Log("Hello41241");
	}
}
