using System;
using UnityEngine;

namespace Runner.Control
{
    public class PlayerCompetitor : Competitor 
    {
        
        [SerializeField] AudioClip onDeathSound; // Sound played when the player dies

        public event Action onDeath; // Event triggered when the player dies
        public override void OnCollison()
        {
            base.OnCollison();
            if (onDeath != null)
            {
                if (onDeathSound != null)
                {
                    Singleton.Instance.Fader.FadeOutImmediate(); // Fade out the screen immidiately
                    Singleton.Instance.AudioPlayer.PlayAudio(onDeathSound, volume: 0.5f); // Play the death sound
                    Singleton.Instance.Fader.FadeIn(1.2f); // Fade in the screen
                }
                onDeath(); // Trigger the onDeath event
            }
        }
    }
}