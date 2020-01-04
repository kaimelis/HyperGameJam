using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelDesigner), true)]
public class LevelDesignerInterface : Editor
{
    LevelDesigner levelDesigner;

    //  bool showPosition;
    int temp;

    private void OnEnable()
    {
        levelDesigner = (LevelDesigner) target;
    }

    public override void OnInspectorGUI()
    {

        levelDesigner = (LevelDesigner) target;

        //shows public variables from base class
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate", GUILayout.Width(190)))
        {
          levelDesigner.Generate();

        }
    }
}
