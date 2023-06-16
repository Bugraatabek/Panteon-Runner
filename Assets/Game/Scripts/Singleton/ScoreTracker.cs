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

    public void IncreaseScore(int amount)
    {
        _score += amount;   // Increase the score by the amount when a coin is collected
        if (onScoreChange != null)
        {
            onScoreChange();   // Invoke the onScoreChange event
        }
    }
}
