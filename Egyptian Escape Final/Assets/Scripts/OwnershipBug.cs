using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OwnershipBug : MonoBehaviourPunCallbacks
{
    void Start()
    {
        photonView.OwnershipTransfer = OwnershipOption.Takeover;
    }

    void OnMouseDown()
    {
        if (!photonView.IsMine)
        {
            this.photonView.RequestOwnership();
        }
    }
    public void SeletedGO()
    {
        if (!photonView.IsMine)
        {
            print("select");
            this.photonView.RequestOwnership();
        }
    }
    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        print(targetView.Owner);
        // OnOwnershipRequest gets called on every script that implements it every time a request for ownership transfer of any object occurs
        // So, firstly, only continue if this callback is getting called because *this* object is being transferred
        if (targetView.gameObject != this.gameObject)
        {
            return;
        }
        if (targetView.Owner == null)
        {
            Debug.Log(requestingPlayer.NickName + " requested ownesrhip of " + targetView.gameObject.name + "and, seeing as nobody else owns it, so we'll let them have it.");
            targetView.TransferOwnership(requestingPlayer);
        }
        else
        {
            Debug.Log(requestingPlayer.NickName + " requested ownership of " + targetView.gameObject.name + "and, seeing as " + targetView.Owner.NickName + " has finished with it, we'll let them have it.");
            targetView.TransferOwnership(requestingPlayer);
        }
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        // OnOwnershipTransfered gets called on every script that implements it every time any object transfers ownership
        // So, firstly, only continue if this callback is getting called because *this* object is being transferred
        if (targetView.gameObject != this.gameObject)
        {
            return;
        }
        Debug.Log(targetView.gameObject.name + " ownership transferred!");
    }
}