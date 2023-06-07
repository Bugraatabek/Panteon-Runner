using System;
using UnityEngine;
using UnityEngine.AI;

namespace Runner.Control
{
    public class Competitor : MonoBehaviour, ICompetitor
    {
        [SerializeField] AudioClip onDeathSound; // Sound played when the player dies
        [SerializeField] private Transform _restartPoint; // Restart point for the competitor
        public static event Action onDeath; // Event triggered when the player dies

        NavMeshAgent navMesh;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            navMesh = GetComponent<NavMeshAgent>();
        }

        public void OnCollison()
        {
            rb.isKinematic = true; // Disable rigidbody physics
            navMesh.enabled = false; // Disable NavMeshAgent
            transform.position = _restartPoint.position; // Reset the competitor's position to the restart point
            navMesh.enabled = true; // Enable NavMeshAgent
            rb.isKinematic = false; // Enable rigidbody physics

            if (onDeath != null && this.gameObject.CompareTag("Player"))
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
