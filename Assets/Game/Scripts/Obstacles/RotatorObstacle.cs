using System.Collections;
using Runner.Control;
using UnityEngine;
using UnityEngine.AI;

namespace Runner.Obstacles
{
    public class RotatorObstacle : MonoBehaviour, ISpecialObstacle
    {
        [SerializeField] float _pushForce = 15f; // The magnitude of the push force applied to competitors

        //ISpecialObstacle
        public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint)
        {
            contactPoint.y = 0; // Set the contact point's Y component to zero to ensure a horizontal force
            Vector3 forceDirection = -contactPoint; // Calculate the direction in which the competitor should be pushed
            competitorRB.AddForce(forceDirection * _pushForce, ForceMode.Impulse); // Apply the push force to the competitor's rigidbody
        }
    }
}
