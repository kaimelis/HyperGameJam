using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettingsGear : MonoBehaviour
{
    [SerializeField]
    GameObject soundsButton, creditsButton;
    [SerializeField]
    SettingsScriptable settingsScriptable;
    public void ToggleSettings()
    {
        if (settingsScriptable.activeSettings)//Hide
        {
            settingsScriptable.activeSettings = false;
            soundsButton.SetActive(false);
            creditsButton.SetActive(false);
        }
        else//Show
        {
            settingsScriptable.activeSettings = true;
            soundsButton.SetActive(true);
            creditsButton.SetActive(true);
        }

    }
}
