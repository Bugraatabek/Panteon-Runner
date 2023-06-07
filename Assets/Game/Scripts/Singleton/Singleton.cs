using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // Component instances
    public DeathTracker DeathTracker { get { return _deathTracker; } }  // Provides access to the DeathTracker component
    public PaintPercentageTracker PaintPercentageTracker { get { return _paintPercentageTracker; } }  // Provides access to the PaintPercentageTracker component
    public PhaseManager PhaseManager { get { return _phaseManager; } }  // Provides access to the PhaseManager component
    public RankTracker RankTracker { get { return _rankTracker; } }  // Provides access to the RankTracker component
    public ScoreTracker ScoreTracker { get { return _scoreTracker; } }  // Provides access to the ScoreTracker component
    public AudioPlayer AudioPlayer { get { return _audioPlayer; } }  // Provides access to the AudioPlayer component
    public Fader Fader { get { return _fader; } }  // Provides access to the Fader component

    // Private component references
    DeathTracker _deathTracker;
    PaintPercentageTracker _paintPercentageTracker;
    PhaseManager _phaseManager;
    RankTracker _rankTracker;
    ScoreTracker _scoreTracker;
    AudioPlayer _audioPlayer;
    Fader _fader;

    // Singleton instance
    public static Singleton Instance { get; private set; }

    private void Awake()
    {
        transform.parent = null;

        // Check if an instance already exists
        if (Instance)
        {
            // Destroy the current instance to ensure only one instance exists
            Destroy(gameObject);
        }
        else
        {
            // Assign this instance as the singleton instance
            Instance = this;
        }

        // Get references to the various components
        _fader = GetComponent<Fader>();
        _deathTracker = GetComponent<DeathTracker>();
        _paintPercentageTracker = GetComponent<PaintPercentageTracker>();
        _phaseManager = GetComponent<PhaseManager>();
        _rankTracker = GetComponent<RankTracker>();
        _scoreTracker = GetComponent<ScoreTracker>();
        _audioPlayer = GetComponentInChildren<AudioPlayer>();
    }
}
