using System;
using Runner.Painting;
using UnityEngine;

public class PaintPercentageTracker : MonoBehaviour 
{
    private int _percentage;                                // Stores the current paint percentage
    public int percentage { get {return _percentage; } }    // Exposes the paint percentage as a property
    public event Action onPercentageUpdate;                 // Event triggered when the paint percentage is updated
    public event Action onGameFinished;                     // Event triggered when the paint percentage reaches 100

    private void Awake() 
    {
        _percentage = 0;                                    // Initialize the paint percentage to 0
    }

    private void OnEnable() 
    {
        Paintable.onPaint += UpdatePercentage;              // Subscribe to the onPaint event of Paintable objects
    }

    // Update the paint percentage and invoke the onPercentageUpdate event
    private void UpdatePercentage()
    {
        _percentage += 1;                                   // Increment the paint percentage by 1

        if(onPercentageUpdate != null)
        {
            onPercentageUpdate();                           // Trigger the onPercentageUpdate event
        }

        // Check if the paint percentage reaches 100
        if(_percentage == 100)
        {
            if(onGameFinished != null)
            {
                onGameFinished();                           // Trigger the onGameFinished event
            }
        }
    }
}
