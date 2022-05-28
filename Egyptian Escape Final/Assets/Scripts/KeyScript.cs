using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//This script is responsible for the automatic rotation of the keys in the correct direction when in proximity of the doors.

public class KeyScript : MonoBehaviourPun
{
    public string keyType;
    public DoorScript ds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.name + "enter");
        if (keyType == "silverKey")
        {
            if (other.name == "silverDoor")
            {
                gameObject.transform.rotation = other.transform.rotation;
                photonView.RPC("ChangeValueDoor", RpcTarget.All, "silverDoor", true);
            }
        }
        else if (keyType == "goldKey")
        {
            if (other.name == "goldDoor")
            {
                gameObject.transform.rotation = other.transform.rotation;
                photonView.RPC("ChangeValueDoor", RpcTarget.All, "goldDoor", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print(other.name + "exit");
        if (keyType == "silverKey")
        {
            if (other.name == "silverDoor")
            {
                photonView.RPC("ChangeValueDoor", RpcTarget.All, "silverDoor", false);
            }
        }
        else if (keyType == "goldKey")
        {
            if (other.name == "goldDoor")
            {
                photonView.RPC("ChangeValueDoor", RpcTarget.All, "goldDoor", false);
            }
        }
    }
    [PunRPC]
    public void ChangeValueDoor(string doorName, bool b)
    {
        ds.DoorLock(doorName, b);
    }
}
