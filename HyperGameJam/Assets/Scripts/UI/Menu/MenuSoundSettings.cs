using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSoundSettings : MonoBehaviour
{
    [SerializeField]
    SettingsSoundScriptable settingsSoundScriptable;
    [SerializeField]
    Image soundImage;
    [SerializeField]
    Sprite soundOff, soundOn;

    private void Start()
    {
        if (settingsSoundScriptable.activeSettings)//if active sound
        {
            soundImage.sprite = soundOn;
        }
        else
        {
            soundImage.sprite = soundOff;
        }
    }
    public void ToggleSounds()
    {
        
        if(settingsSoundScriptable.activeSettings)//if active sound
        {
            soundImage.sprite = soundOff;
            AudioListener.volume = 0f;
            settingsSoundScriptable.activeSettings = false;
        }
        else
        {
            soundImage.sprite = soundOn;
            AudioListener.volume = 1f;
            settingsSoundScriptable.activeSettings = true;
        }
    }
}
