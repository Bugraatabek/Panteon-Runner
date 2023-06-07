using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Obstacles
{
    public class RotatingPlatform : MonoBehaviour, ISpecialObstacleRoutine
    {
        private int _direction = -1; // Direction of the push force (-1 = left, 1 = right)
        [Tooltip("checked = pushRight / unchecked = pushLeft")]
        [SerializeField] private bool _pushRight; // Flag indicating the direction of the push force
        [SerializeField] private float _pushForce; // Magnitude of the push force

        List<Rigidbody> competitors = new List<Rigidbody>(); // List of competitors affected by the rotating platform

        private void Awake()
        {
            if (_pushRight)
            {
                _direction = 1; // Set the direction to right if the pushRight flag is true
            }
            else
            {
                _direction = -1; // Set the direction to left if the pushRight flag is false
            }
        }

        private void FixedUpdate()
        {
            if (competitors.Count == 0) return; // If there are no competitors, exit the method

            foreach (var competitor in competitors)
            {
                competitor.AddForce(Vector3.right * _direction * _pushForce, ForceMode.VelocityChange); // Apply the push force to the competitors
            }
        }

        //ISpecialObstacleRoutine
        public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint)
        {
            competitors.Add(competitorRB); // Add the competitor to the list of affected competitors

            if (competitorRB.CompareTag("Player")) return; // If the competitor is the player, exit the method

            competitorRB.GetComponent<IAIController>().Steer(Vector3.right * _direction * -1); // Let AI know it has to steer in which direction by using IAIController interface
        }

        public void OnExit(Rigidbody rb)
        {
            competitors.Remove(rb); // Remove the competitor from the list of affected competitors

            if (rb.CompareTag("Player")) return; // If the competitor is the player, exit the method

            rb.GetComponent<IAIController>().StopSteering(); // Let AI know it has to stop steering by using IAIController interface
        }
    }
}