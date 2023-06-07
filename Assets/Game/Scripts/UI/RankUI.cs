using TMPro;
using UnityEngine;

public class RankUI : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI rankText;  // Text component for displaying the rank

    private void FixedUpdate() 
    {
        rankText.text = $"Rank: {Singleton.Instance.RankTracker.playersRank} / {Singleton.Instance.RankTracker.competitorCount}";  // Update the rank text with current player rank and competitor count
    }    
}
