using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _highScoreText;

    private void Awake()
    {
        FindObjectOfType<ScoreManager>()._onScoreUpdated += UpdateScoreUI;
        FindObjectOfType<ScoreManager>()._onHighScoreUpdated += UpdateHighScoreUI;

        UpdateScoreUI(0);
        UpdateHighScoreUI(0);
    }

    private void UpdateScoreUI(int updatedScore)
    {
        _scoreText.text = updatedScore.ToString();
    }

    private void UpdateHighScoreUI(int updatedScore)
    {
        _highScoreText.text = updatedScore.ToString();
    }

    private void OnDisable()
    {
        FindObjectOfType<ScoreManager>()._onScoreUpdated -= UpdateScoreUI;
        FindObjectOfType<ScoreManager>()._onHighScoreUpdated -= UpdateHighScoreUI;
    }
}
