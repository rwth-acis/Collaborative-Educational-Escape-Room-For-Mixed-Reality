using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PaintingAnim : MonoBehaviourPun
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

   

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OpenPaint()
    {
        print("open");
        anim.SetBool("open", true);
    }
}
