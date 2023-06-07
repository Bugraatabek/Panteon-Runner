using System;
using Runner.Collisions;
using Runner.Control;
using UnityEngine;
using UnityEngine.AI;

namespace Runner.Control
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIController : MonoBehaviour, IAIController
    {
        NavMeshAgent navMesh; // Reference to the NavMeshAgent component
        [SerializeField] Transform destinationPrefab; // Destination prefab for the AI
        [SerializeField] private bool _shouldRun = false; // Flag to determine if the AI should run

        [SerializeField] private float _randomSteeringSpeedFloor = 17f; // Minimum random steering speed
        [SerializeField] private float _randomSteeringSpeedCeiling = 17.5f; // Maximum random steering speed
        private float _steerSpeed; // Randomly chosen steering speed for the AI

        private bool _shouldSteer = false; // Flag to determine if the AI should steer
        Vector3 _steerDirection; // Direction in which the AI should steer
        Vector3 destination; // Destination position for the AI

        [SerializeField] float waypointTolerance = 1f;
        [SerializeField] Path path;
        Vector3[] waypoints = null;
        int currentWaypointIndex = 0;
        
        private void Awake() 
        {
            navMesh = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
            destination = destinationPrefab.position; // Get the position of the destination prefab
            _steerSpeed = UnityEngine.Random.Range(_randomSteeringSpeedFloor, _randomSteeringSpeedCeiling); // Choose a random steering speed
        }

        private void OnEnable() 
        {
            // Subscribe to the runner and painting phase events
            Singleton.Instance.PhaseManager.onRunnerPhaseStart += StartRunnerControls;
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += StopRunnerControls;
        }

        private void OnDisable() 
        {
            //Unsubscribe to the runner and painting phase events
            Singleton.Instance.PhaseManager.onRunnerPhaseStart -= StartRunnerControls;
            Singleton.Instance.PhaseManager.onPaintingPhaseStart -= StopRunnerControls;
        }

        private void FixedUpdate() 
        {
            if (!_shouldRun) return; // If the AI should not run, exit the method

            if (navMesh.isActiveAndEnabled)
            {
                // Check if the AI should steer and update its position accordingly
                if (_shouldSteer)
                {
                    // Steer the AI by translating its position based on the steer direction and steer speed
                    transform.Translate(_steerDirection * _steerSpeed * Time.fixedDeltaTime);
                }
                
                // Check if there are waypoints to follow and update the destination accordingly
                if (waypoints == null)
                {
                    navMesh.destination = destination; // Set the destination for the NavMeshAgent
                }    
                else
                {
                    // Check if the AI has reached the current waypoint and update the destination accordingly
                    if (currentWaypointIndex == waypoints.Length)
                    {
                        _shouldRun = false;
                        return;
                    }

                    navMesh.destination = waypoints[currentWaypointIndex];
                    navMesh.isStopped = false;

                    if (AtWaypoint())
                    {
                        currentWaypointIndex += 1;
                        return;
                    }
                }
            }
        }

        // Get the position of the current waypoint
        private Vector3 GetCurrentWaypoint()
        {
            return path.GetWaypoint(currentWaypointIndex);
        }

        // Check if the AI has reached the current waypoint within the tolerance distance
        private bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        // Stop the AI from running when the painting phase starts
        private void StopRunnerControls()
        {
            _shouldRun = false;
        }

        // Start the AI running when the runner phase starts
        private void StartRunnerControls()
        {
            _shouldRun = true;
        }

        // Implement the Steer method from the IAIController interface
        public void Steer(Vector3 direction)
        {
            _steerDirection = direction; // Set the steer direction
            _shouldSteer = true; // Enable steering
        }

        // Implement the StopSteering method from the IAIController interface
        public void StopSteering()
        {
            _shouldSteer = false; // Disable steering
        }
    }
}
