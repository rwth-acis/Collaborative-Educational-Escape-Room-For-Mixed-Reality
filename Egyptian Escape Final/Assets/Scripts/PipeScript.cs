using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//The PipeScript is in charge of rotating the seperate sections of the Pipe Game.

public class PipeScript : MonoBehaviourPun
{
    public PipeGameManager pipeGM;
    public bool isSolved;
    Vector3 defRot;
    // Start is called before the first frame update
    void Start()
    {
        defRot = transform.eulerAngles;
        int[] ranRotation = new int[] { 90, 180, 360 };
        int r = ranRotation[Random.Range(0, ranRotation.Length)];
        print(r);
        transform.Rotate(0, 0, r);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RotatePipe()
    {
        if (!isSolved)
        {
            transform.Rotate(0, 0, 90);
            print(transform.localRotation.eulerAngles.z + " " + defRot.z);
            float dist = transform.localRotation.eulerAngles.z - defRot.z;
            if (Mathf.Abs(dist) <= 10)
            {
                isSolved = true;
                this.photonView.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                if (photonView.IsMine)
                {
                    print("solved");
                    photonView.RPC("Match", RpcTarget.All, gameObject.name);
                }
            }
        }
    }
    [PunRPC]
    public void Match(string go)
    {
        print(go);
        isSolved = true;
        pipeGM.Match(go);
    }
}