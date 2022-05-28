using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//There is a Clue Diamond attached to the Magic Square, but it is not visible at the beginning of the game.
//Only when the last box from the Magic Square is inserted correctly does the Clue Diamond appear,
//subsequently delivering a clue about the next task.
//This is achieved with the MagicSquareScript.

public class MagicSquareScript : MonoBehaviour
{
    public List<GameObject> cubeSolved = new List<GameObject>();
    public GameObject clueGO;
    public GameObject diamond;
    public void Match(string cubeNo)
    {
        for (int i = 0; i < cubeSolved.Count; i++)
        {
            if (cubeSolved[i].name == cubeNo)
            {
                cubeSolved.Remove(cubeSolved[i]);
                if (cubeSolved.Count == 0)
                    diamond.SetActive(true);
            }
        }
    }
    public void ShowClue()
    {
        print("show");
        clueGO.SetActive(true);
    }
}
