using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//In the second task, the two Papyri must be joined together.
//This is where the SnapScript is of use, since it allows the Papyri to snap together,
//which leads to activating the Solution Rack.


public class SnapScript : MonoBehaviourPun
{
    public GameObject snapGO;
    GameObject GOTrigger;
    public GameObject solutionRack;
    public PaperScript ps;

    void Start()
    {

    }

    public void OnRelease()
    {
        if (GOTrigger != null)
        {
            GOTrigger.GetComponent<BoxCollider>().enabled = false;
            GOTrigger.transform.position = snapGO.transform.position;
            GOTrigger.transform.rotation = snapGO.transform.rotation;
            GOTrigger.transform.SetParent(transform.parent);
            print("snap");
            ps.Snap();
            //if (photonView.IsMine)
            //    photonView.RPC("ActiveGameObject", RpcTarget.All);
        }
    }
    [PunRPC]
    public void ActiveGameObject()
    {
        print("solution");
        solutionRack.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag == "paper")
        {
            GOTrigger = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube")
        {
            GOTrigger = null;
        }
    }
}