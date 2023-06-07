using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class DeathUI : MonoBehaviour 
    {
        [SerializeField] TextMeshProUGUI deathText;  // Text component for displaying death count
        private void OnEnable() 
        {
            Singleton.Instance.DeathTracker.onDeath += UpdateUI;  // Subscribe to the death event
        }
        private void OnDisable() 
        {
            Singleton.Instance.DeathTracker.onDeath -= UpdateUI;  // Unsubscribe to the death event
        }

        private void Start() 
        {
            UpdateUI();  // Update the UI initially
        }

        private void UpdateUI()
        {
            deathText.text = $"Death: {Singleton.Instance.DeathTracker.deathCount}";  // Update the death count text
        }
    }
}
