using System.Collections;
using System.Collections.Generic;
using Runner.Control;
using UnityEngine;

public class RankTracker : MonoBehaviour
{
    List<Competitor> competitors = new List<Competitor>();
    List<float> competitorPositions = new List<float>();

    private int _competitorCount;
    private int _playersRank;
    public int competitorCount { get { return _competitorCount; } }
    public int playersRank { get { return _playersRank; } }

    Transform playerTransform;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;

        // Find all Competitor objects in the scene and add them to the competitors list
        foreach (var competitor in FindObjectsOfType<Competitor>())
        {
            competitors.Add(competitor);
        }

        _competitorCount = competitors.Count;   // Set the competitor count
    }

    private void FixedUpdate()
    {
        CalculatePlayerRank();   // Calculate the player's rank
    }

    private void CalculatePlayerRank()
    {
        competitorPositions = new List<float>();

        // Get the positions of all competitors and store them in the competitorPositions list
        foreach (var competitor in competitors)
        {
            competitorPositions.Add(GetCompetitorPosition(competitor));
        }

        competitorPositions.Sort();   // Sort the positions in ascending order

        for (int i = 0; i < competitorPositions.Count; i++)
        {
            if (competitorPositions[i] == playerTransform.position.z)
            {
                _playersRank = (10 - i);   // Calculate the player's rank based on their position
            }
        }
    }

    private float GetCompetitorPosition(Competitor competitor)
    {
        return competitor.transform.position.z;   // Get the z-position of the competitor's transform
    }
}
