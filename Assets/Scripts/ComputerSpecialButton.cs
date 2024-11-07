using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ComputerSpecialButton : MonoBehaviour
{
    public Computer computerMenuManager;
    public string Handtag;
    public string TypeOfKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == Handtag)
        {
            if (TypeOfKey == "scrollDown") 
            {
                computerMenuManager.OpenMenu(computerMenuManager.Menus[computerMenuManager.CurrentMenuIndex-1].name);
            }
            else if (TypeOfKey == "scrollUp")
            {
                computerMenuManager.OpenMenu(computerMenuManager.Menus[computerMenuManager.CurrentMenuIndex+1].name);
            }
            else if (TypeOfKey == "enter")
            {
                
            }
        }
    }
}
