using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _highScore;
    [SerializeField]
    public InGameUIScriptable scriptable;

    public event Action<int> _onScoreUpdated;
    public event Action<int> _onHighScoreUpdated;

    private void Start()
    {
        _score = 0;
    }

    private void Awake()
    {
        HelixPartOre._onHelixDestroyed += AddScore;
        HelixPassed._onHelixPassed += AddScore;
    }

    private void AddScore(int amount)
    {
        _score += amount;
        _onScoreUpdated?.Invoke(_score);

        if (_score > scriptable.highScore)
        {
            _highScore = _score;
            scriptable.highScore = _score;
            _onHighScoreUpdated?.Invoke(_highScore);
        }
    }

    private void OnDisable()
    {
        HelixPartOre._onHelixDestroyed -= AddScore;
        HelixPassed._onHelixPassed -= AddScore;
    }
}
