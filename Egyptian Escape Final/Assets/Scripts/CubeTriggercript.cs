using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//In the Magic Square task, the players have to insert the numbered boxes in their correct spot.
//This script allows the inserted box to fit in its correct position.

public class CubeTriggercript : MonoBehaviourPun
{
    public MagicSquareScript m_MagicSquareScript;
    public GameObject GOTrigger;
    public Vector3 m_Position;

    private void Start()
    {
        m_Position = gameObject.transform.position;
    }
    public void OnRelease()
    {
        if (GOTrigger != null)
        {
            GetComponent<BoxCollider>().enabled = false;
            transform.position = GOTrigger.transform.position;
            this.photonView.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
            if (photonView.IsMine)
                photonView.RPC("Match", RpcTarget.All, gameObject.name);

        }
        else
        {
            transform.position = m_Position;
        }
    }
    [PunRPC]
    public void Match(string go)
    {
        m_MagicSquareScript.Match(go);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            if (other.name == gameObject.name)
            {
                GOTrigger = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube")
        {
            if (other.name == gameObject.name)
            {
                GOTrigger = null;
            }
        }
    }
}
