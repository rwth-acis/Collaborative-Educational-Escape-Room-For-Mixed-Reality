using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for managing the Pipe Game.
//It counts down the remaining unsolved sections by receiving the status of each section from the PipeScript until the last section is solved.
//When all sections are solved, it reveals the gold key.

public class PipeGameManager : MonoBehaviour
{
    public List<GameObject> pipeGO;
    public GameObject key;


    public void Match(string cubeNo)
    {
        for (int i = 0; i < pipeGO.Count; i++)
        {
            if (pipeGO[i].name == cubeNo)
            {
                pipeGO[i].GetComponent<PipeScript>().isSolved = true;
                pipeGO.Remove(pipeGO[i]);
                if (pipeGO.Count == 0)
                    key.SetActive(true);
            }
        }
    }

}
