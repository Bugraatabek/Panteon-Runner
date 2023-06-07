using System;
using Runner.Control;
using UnityEngine;

public class DeathTracker : MonoBehaviour 
{
    private int _deathCount;
    public int deathCount { get{ return _deathCount; } }
    public event Action onDeath;

    private void Awake() 
    {
        _deathCount = 0;
    }

    
    private void OnEnable() 
    {
        // Subscribe to the onDeath event when the object is enabled
        Competitor.onDeath +=  CountDeath;
    }

    
    private void CountDeath()
    {
        _deathCount += 1;   // Increase the death count by 1 
        if(onDeath != null)
        {
            onDeath();  //invoke the onDeath event
        }
    }
}
