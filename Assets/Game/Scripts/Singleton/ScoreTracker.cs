using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Collisions;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int _score;
    public int score { get { return _score; } }
    public event Action onScoreChange;

    void Awake()
    {
        _score = 0;   // Initialize the score to 0
    }

    private void OnEnable()
    {
        CoinCollisionHandler.onCoinCollect += OnCoinCollect;   // Subscribe to the onCoinCollect event
    }

    private void OnCoinCollect()
    {
        _score += 5;   // Increase the score by 5 when a coin is collected
        if (onScoreChange != null)
        {
            onScoreChange();   // Invoke the onScoreChange event
        }
    }
}
