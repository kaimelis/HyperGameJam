using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[CustomEditor(typeof(InGameUI))]
public class TweakUI : Editor
{
    [SerializeField]
    InteractionSound interactionSound;

    float interactionSoundPitch;
    void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("In Game UI Serialized Fields", EditorStyles.boldLabel, GUILayout.Height(20));
        InGameUI inGameUI = (InGameUI)target;
        DrawDefaultInspector();
        EditorGUILayout.LabelField("In Game UI Score Tweeker", EditorStyles.boldLabel, GUILayout.Height(20));
        inGameUI.SetHighScore(EditorGUILayout.IntSlider(inGameUI.GetHighScore(), 0, 1000000));
        inGameUI.SetCurrenScore(EditorGUILayout.IntSlider(inGameUI.GetCurrentScore(), 0, 1000000));

        /*
        EditorGUILayout.LabelField("Audio Tester", EditorStyles.boldLabel, GUILayout.Height(20));
        if (GUILayout.Button("Play random pitch interaction sound"))
        {
            interactionSound.PlayRandomPitch(); // how do i call this?
        }
        interactionSoundPitch = EditorGUILayout.Slider("Pitch to play", interactionSoundPitch, -3f, 3f);
        if (GUILayout.Button("Play selected above pitch interaction sound"))
        {
            interactionSound.SetAudioPlay(interactionSoundPitch); // how do i call this?
        }
        */
    }
}
