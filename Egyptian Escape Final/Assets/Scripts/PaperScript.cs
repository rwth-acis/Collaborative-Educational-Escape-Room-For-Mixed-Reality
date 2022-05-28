using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


//This script activates the solution rack for the Papyrus Riddle.
//It is activated after the two Papyri snap together.


public class PaperScript : MonoBehaviourPun
{
    public GameObject solutionRack;
   
    void Start()
    {

    }

    public void Snap()
    {
        this.photonView.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
        if (photonView.IsMine)
            photonView.RPC("ActiveGameObject", RpcTarget.All);
    }
    [PunRPC]
    public void ActiveGameObject()
    {
        print("solution");
        solutionRack.SetActive(true);
    }
}
