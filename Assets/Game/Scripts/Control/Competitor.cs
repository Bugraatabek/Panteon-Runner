using System;
using UnityEngine;
using UnityEngine.AI;

namespace Runner.Control
{
    public class Competitor : MonoBehaviour, ICompetitor
    {
        [SerializeField] private Transform _restartPoint; // Restart point for the competitor

        NavMeshAgent navMesh;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            navMesh = GetComponent<NavMeshAgent>();
        }

        public virtual void OnCollison()
        {
            rb.isKinematic = true; // Disable rigidbody physics
            navMesh.enabled = false; // Disable NavMeshAgent
            transform.position = _restartPoint.position; // Reset the competitor's position to the restart point
            navMesh.enabled = true; // Enable NavMeshAgent
            rb.isKinematic = false; // Enable rigidbody physics
        }
    }
}
