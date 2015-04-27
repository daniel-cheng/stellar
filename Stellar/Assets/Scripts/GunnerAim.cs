using UnityEngine;
using System.Collections;

public class GunnerAim : Photon.MonoBehaviour
{
    public bool isEnabled = true;
    public Transform baseObject;
    public Transform guns;
    public float xSpeed = 250.0f;
    public float ySpeed = 250.0f;

    private Quaternion targetBaseAngles = new Quaternion();
    private Quaternion targetGunsAngles = new Quaternion();
    private Vector3 oldMousePosition;
    private Vector3 deltaMousePosition;
    private float x = 0.0f;
    private float y = 0.0f;
    public float xMinLimit = -0.0f;
    public float xMaxLimit = 0.0f;
    public float yMinLimit = -0.0f;
    public float yMaxLimit = 0.0f;

    // Use this for initialization
    void Start()
    {
        oldMousePosition = Input.mousePosition;
        deltaMousePosition = Vector3.zero;

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y += Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            x = Mathf.Clamp(x % 360.0f, xMinLimit, xMaxLimit);
            y = Mathf.Clamp(y % 360.0f, 0.0f, 90.0f);

            //use mouse X to rotate around Y axis, mouse Y to rotate around X axis.
            baseObject.localEulerAngles = new Vector3(0.0f, x, 0.0f);
            guns.localEulerAngles = new Vector3(-y, 0.0f, 0.0f);
        }
        else
        {
            baseObject.transform.localRotation = Quaternion.Slerp(baseObject.transform.localRotation, targetBaseAngles, Time.deltaTime * 5.0f);
            guns.transform.localRotation = Quaternion.Slerp(guns.transform.localRotation, targetGunsAngles, Time.deltaTime * 5.0f);
   
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(baseObject.transform.localRotation);
            stream.SendNext(guns.transform.localRotation);
        }
        else
        {
            // Network player, receive data
            this.targetBaseAngles = (Quaternion)stream.ReceiveNext();
            this.targetGunsAngles = (Quaternion)stream.ReceiveNext();
        }
    }
}