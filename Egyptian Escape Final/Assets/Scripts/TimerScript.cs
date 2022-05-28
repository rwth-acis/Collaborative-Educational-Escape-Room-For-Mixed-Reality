using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using System;
using UnityEngine.UI;
using Photon.Pun.UtilityScripts;
using UnityEngine.SceneManagement;

//The TimerScript provides the players with a visible countdown timer starting at 20 minutes.
//When the time is up, this script redirects the game users into the "Game Over" scene.


public class TimerScript : MonoBehaviourPunCallbacks
{
    public GameObject GameOverUI;
    public TMP_Text timerLabel;
    bool startTimer = false;
    double timerIncrementValue;
    double startTime;
    [SerializeField] float timer = 120;
    ExitGames.Client.Photon.Hashtable CustomeValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        timer = 1199;
        if (!startTimer) return;
        timerIncrementValue = PhotonNetwork.Time - startTime;
        timer -= ((float)timerIncrementValue);
        string minutes = ((int)timer / 60).ToString();
        string seconds = (timer % 60).ToString("f2");
        timerLabel.text = "Timer left : " + minutes + ":" + seconds;
        if (timer <= 0)
        {
            //GameOverUI.SetActive(true);
            SceneManager.LoadScene(1);

        }
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            CustomeValue = new ExitGames.Client.Photon.Hashtable();
            startTime = PhotonNetwork.Time;
            startTimer = true;
            CustomeValue.Add("StartTime", startTime);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        else
        {
            startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
            startTimer = true;
        }
    }
}