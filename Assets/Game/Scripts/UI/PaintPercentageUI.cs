using System;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class PaintPercentageUI : MonoBehaviour 
    {
        [SerializeField] TextMeshProUGUI percentageText;  // Text component for displaying paint percentage
        private void OnEnable() 
        {
            Singleton.Instance.PaintPercentageTracker.onPercentageUpdate += UpdateUI;  // Subscribe to the percentage update event
        }

        private void OnDisable() 
        {
            Singleton.Instance.PaintPercentageTracker.onPercentageUpdate -= UpdateUI;  // Unsubscribe to the percentage update event
        }
        private void Start() 
        {
            UpdateUI();  // Update the UI initially
        }

        private void UpdateUI()
        {
            percentageText.text = $"Paint Percentage: %{Singleton.Instance.PaintPercentageTracker.percentage}";  // Update the paint percentage text
        }
    }
}
