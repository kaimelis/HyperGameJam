using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _highScore;

    public event Action<int> _onScoreUpdated;
    public event Action<int> _onHighScoreUpdated;

    private void Start()
    {
        _score = 0;
    }

    private void Awake()
    {
        Slice._onHelixDestroyed += AddScore;
        HelixPassed._onHelixPassed += AddScore;
    }

    private void AddScore(int amount)
    {
        _score += amount;
        _onScoreUpdated?.Invoke(_score);

        if (_score > _highScore)
        {
            _highScore = _score;
            _onHighScoreUpdated?.Invoke(_highScore);
        }
    }

    private void OnDisable()
    {
        Slice._onHelixDestroyed -= AddScore;
        HelixPassed._onHelixPassed -= AddScore;
    }
}
