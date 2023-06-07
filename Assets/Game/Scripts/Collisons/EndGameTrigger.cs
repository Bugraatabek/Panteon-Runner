using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Control;
using UnityEngine;

namespace Runner.Collisions
{
    public class EndGameTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _paintingPhasePosition; // The position to teleport the player to when Painting Phase starts

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("AI"))
            {
                other.gameObject.SetActive(false); // Deactivate the AI object if it collides with the trigger
                return;
            }

            if (other.CompareTag("Player"))
            {
                foreach (var ai in FindObjectsOfType<AIController>())
                {
                    ai.gameObject.SetActive(false); // Deactivate all AI objects in the scene
                }

                Singleton.Instance.PhaseManager.PaintingPhase(); // Transition to the painting phase using the PhaseManager

                other.transform.position = _paintingPhasePosition.position; // Teleport the player to the specified position
            }
        }
    }
}

