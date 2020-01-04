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

    private ScoreManager _scoreManager;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        if(_scoreManager != null)
            _scoreManager._onScoreUpdated += UpdateScoreUI;

        if (_scoreManager != null)
            _scoreManager._onHighScoreUpdated += UpdateHighScoreUI;

        UpdateScoreUI(0);
        UpdateHighScoreUI(0); ;
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
        if (_scoreManager != null)
            _scoreManager._onScoreUpdated -= UpdateScoreUI;
        if (_scoreManager != null)
            _scoreManager._onHighScoreUpdated -= UpdateHighScoreUI;
    }
}
