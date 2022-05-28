using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AvatarMovementSynchronizer : MonoBehaviourPun
{



    void Update()
    {
        if (photonView.IsMine)
        {
            // set the position based on the camera
            transform.position = Camera.main.transform.position;
            transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward, Camera.main.transform.up);
        }
    }
}
