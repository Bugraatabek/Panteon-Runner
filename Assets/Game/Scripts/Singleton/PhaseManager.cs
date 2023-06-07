using System;
using System.Collections;
using Runner.Control;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    private bool _runnerPhase = false;   // Flag indicating if it's currently the runner phase
    public event Action onRunnerPhaseStart;        // Event triggered when the runner phase starts
    public event Action onPaintingPhaseStart;      // Event triggered when the painting phase starts
    public event Action onGameFinished;            // Event triggered when the game finishes

    private void Start()
    {
        // Subscribe to the onGameFinished event of the PaintPercentageTracker
        Singleton.Instance.PaintPercentageTracker.onGameFinished += EndGame;

        StartCoroutine(WaitAndStartRace());   // Start the race coroutine
    }

    private void EndGame()
    {
        if (onGameFinished != null)
        {
            onGameFinished();   // Trigger the onGameFinished event
        }
    }

    private IEnumerator WaitAndStartRace()
    {
        while (true)
        {
            if (!_runnerPhase)
            {
                _runnerPhase = true;   // Set the runner phase flag to true
                yield return new WaitForSeconds(3);   // Wait for 3 seconds before game starts
            }

            if (_runnerPhase)
            {
                RunnerPhase();   // Start the runner phase
                yield break;   // Exit the coroutine
            }
        }
    }

    public void PaintingPhase()
    {
        if (onPaintingPhaseStart != null)
        {
            onPaintingPhaseStart();   // Trigger the onPaintingPhaseStart event
        }
    }

    private void RunnerPhase()
    {
        if (onRunnerPhaseStart != null)
        {
            onRunnerPhaseStart();   // Trigger the onRunnerPhaseStart event
        }
    }
}
