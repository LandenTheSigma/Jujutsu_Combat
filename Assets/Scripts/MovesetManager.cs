using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesetManager : MonoBehaviour
{
    public Moveset[] Movesets;

    public GameObject LHand;
    public GameObject RHand;
    public GameObject body;
    public stats stats;

    public string StartingMovesetName = "GOJO";
    public Moveset Moveset;

    void Start()
    {       
        for (int i = 0; i < Movesets.Length; i++) { 
            Moveset = Movesets[i];
            Moveset.Body = body;
            Moveset.RHand = RHand;
            Moveset.LHand = LHand;
            Moveset.stats = stats;
        }

        setMovesetActive(StartingMovesetName);
    }

    public void setMovesetActive(string Name)
    {
        for (int i = 0; i < Movesets.Length; i++)
        {
            Moveset ms = Movesets[i];
            if (ms.Name == Name)
            {
                ms.Active = true;             
                Moveset = ms;
            }
            else
            {
                ms.Active = false;
            }
        }
    }
}
