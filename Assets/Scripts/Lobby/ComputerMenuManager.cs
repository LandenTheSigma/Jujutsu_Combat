using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject[] Menus;
    public int CurrentMenuIndex = 1;

    public void OpenMenu(string Name)
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            if (Menus[i].name == Name)
            {
                Menus[i].SetActive(true);
                CurrentMenuIndex = i;
            }
            else
            {
                Menus[i].SetActive(false);
            }
        }
    }

    
}
