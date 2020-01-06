using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    StartUIScriptable startUIScriptable;
    [SerializeField]
    GameObject menu, credits;
    private void Start()
    {
        if (startUIScriptable.menuActive && !startUIScriptable.creditsActive)
        {
           // menu.SetActive(true);
          //  credits?.SetActive(false);
        }
        else
        {
           // menu?.SetActive(false);
           // credits?.SetActive(true);
        }
    }
    public void SaveMenu()
    {
        startUIScriptable.menuActive = true;
        startUIScriptable.creditsActive = false;
    }
    public void SaveCredit()
    {
        startUIScriptable.menuActive = false;
        startUIScriptable.creditsActive = true;
    }
}
