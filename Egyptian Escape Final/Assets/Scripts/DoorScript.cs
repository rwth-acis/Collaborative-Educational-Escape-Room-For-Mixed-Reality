using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The DoorScript is responsible for activating the animation of the doors opening.
//It is triggered by the insertion of both the gold and silver keys, which must be simultaneously be inserted in their respective doors.
//The doors open 5 seconds after the key insertion.

public class DoorScript : MonoBehaviour
{
    public bool silverDoor;
    public bool goldDoor;
    bool doorOpen;
    float timer;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen == false)
        {
            if (silverDoor == true && goldDoor == true)
            {
                if (timer <= 5)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    print("doorOpen");
                    anim.SetTrigger("DoorOpen");
                    doorOpen = true;
                }
            }
            else
            {
                if (timer != 0)
                {
                    timer = 0;
                }
            }
        }
    }
    public void DoorLock(string doorName, bool d)
    {
        if (doorName == "silverDoor")
        {
            silverDoor = d;
        }
        else if (doorName == "goldDoor")
        {
            goldDoor = d;
        }
    }
}
