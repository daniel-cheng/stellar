using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour
{
    public static GameObject player;
    public bool offline = true;
    public GameObject offlinePlayer;
    public Transform earth;
    public Transform floatingOrigin;

    // Use this for initialization

    void Awake()
    {
        player = offlinePlayer;
    }

    void Start () {
        if (offline == false)
        {
            
        }
        else
        {
			PhotonNetwork.offlineMode = true;
            //player = (GameObject)Instantiate(offlinePlayer, Vector3.zero, Quaternion.identity);
            //player.transform.parent = this.transform;
            //this.GetComponent<EventNotifier>().OnNetwork();
        }
		PhotonNetwork.ConnectUsingSettings("0.1");
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
        RoomOptions roomOptions = new RoomOptions();
		roomOptions.MaxPlayers = 0;
        PhotonNetwork.CreateRoom(null, roomOptions, null);
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
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Fly>().enabled = true;
        player.GetComponent<ShootRound>().enabled = true;
        player.GetComponent<MouseAim>().enabled = true;
        player.GetComponent<Waypoint>().enabled = true;
        player.GetComponent<EventNotifier>().enabled = true;
        this.GetComponent<EventNotifier>().OnNetwork();
        Destroy(oldPlayer);
	}
}
