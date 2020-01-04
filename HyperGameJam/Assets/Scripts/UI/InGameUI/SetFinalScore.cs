using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFinalScore : MonoBehaviour
{
    [SerializeField]
    public InGameUIScriptable scriptable;

    [SerializeField]
    public Text finalScore;

    public void Start()
    {
        if (finalScore == null)
            Debug.LogError("Dingo eik namo");
        finalScore.text = "SCORE: " + scriptable.finalScore;
    }
}
