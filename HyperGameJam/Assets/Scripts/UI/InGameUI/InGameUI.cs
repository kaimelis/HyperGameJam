using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    InGameUIScriptable scriptable;
    [SerializeField]
    Text highScoreText, currentScoreText;
    int currentScore;


    void Start()
    {
        LevelStart();
        FindObjectOfType<ScoreManager>()._onScoreUpdated += SetCurrenScore;
        FindObjectOfType<ScoreManager>()._onHighScoreUpdated += SetHighScore;
    }
    public void LevelStart()
    {
        LoadHighScore();
        SetCurrenScore(0);
    }
    public void SetHighScore(int highScore)
    {
        scriptable.highScore = highScore;
        LoadHighScore();
    }
    void LoadHighScore()
    {
        highScoreText.text = "High score: " + scriptable.highScore;
    }
    public void SetCurrenScore(int currentScore)
    {
        scriptable.finalScore = currentScore;
        if (currentScore > GetHighScore())
            SetHighScore(currentScore);
        this.currentScore = currentScore;
        LoadCurrentScore();
    }
    void LoadCurrentScore()
    {
        currentScoreText.text = "Current score: " + currentScore;
    }
    public int GetHighScore()
    {
        return scriptable.highScore;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }

}
