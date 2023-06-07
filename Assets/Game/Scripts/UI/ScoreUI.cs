using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;  // Text component for displaying the score

        private void Start() 
        {
            Singleton.Instance.ScoreTracker.onScoreChange += UpdateUI;  // Subscribe to the score change event
            UpdateUI();  // Update the UI with initial score
        }

        private void UpdateUI()
        {
            scoreText.text = $"Score: {Singleton.Instance.ScoreTracker.score}";  // Update the score text with current score
        }
    }
}
