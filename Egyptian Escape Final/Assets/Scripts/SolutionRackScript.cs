using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//After the players select the correct number on the Solution Rack,
//the first key is revealed beside the gates through the SolutionRackScript.


public class SolutionRackScript : MonoBehaviourPun
{
    public GameObject key;
    public void OnRelease()
    {
        this.photonView.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
        if (photonView.IsMine)
            photonView.RPC("ShowKey", RpcTarget.All);
    }
    [PunRPC]
    public void ShowKey()
    {
        print("showkey");
        GetComponent<BoxCollider>().enabled = false;
        key.SetActive(true);
    }
}
