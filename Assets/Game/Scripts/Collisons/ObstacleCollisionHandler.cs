using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Collisions
{
    public class ObstacleCollisionHandler : MonoBehaviour
    {
        ISpecialObstacle iSpecialObstacle = null; // Reference to the ISpecialObstacle interface
        ISpecialObstacleRoutine iSpecialObstacleRoutine = null; // Reference to the ISpecialObstacleRoutine interface

        private void Awake()
        {
            if (this.GetComponent<ISpecialObstacle>() != null)
            {
                iSpecialObstacle = GetComponent<ISpecialObstacle>(); // Assign the ISpecialObstacle component if it exists
            }

            if (this.GetComponent<ISpecialObstacleRoutine>() != null)
            {
                iSpecialObstacleRoutine = this.GetComponent<ISpecialObstacleRoutine>(); // Assign the ISpecialObstacleRoutine component if it exists
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Rigidbody competitorRB = other.gameObject.GetComponent<Rigidbody>();
            if (other.CompareTag("Player") || other.CompareTag("AI"))
            {
                if (this.CompareTag("SpecialObstacle"))
                {
                    iSpecialObstacle.OnCollision(competitorRB, new Vector3()); // Call the OnCollision method on the ISpecialObstacle component with a default contact point because onTriggerEnter doesn't provide a contact point.
                    return;
                }

                if (iSpecialObstacle != null)
                {
                    iSpecialObstacle.OnCollision(competitorRB, new Vector3()); // Call the OnCollision method on the ISpecialObstacle component with a default contact point because onTriggerEnter doesn't provide a contact point.
                }

                other.GetComponent<ICompetitor>().OnCollison(); // Call the OnCollison method on the ICompetitor component of the colliding object
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (iSpecialObstacleRoutine != null)
            {
                iSpecialObstacleRoutine.OnExit(other.gameObject.GetComponent<Rigidbody>()); // Call the OnExit method on the ISpecialObstacleRoutine component with the rigidbody of the exiting object
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Rigidbody competitorRB = other.gameObject.GetComponent<Rigidbody>();
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("AI"))
            {
                Vector3 contactPoint = other.GetContact(0).normal; // Get the contact point normal of the collision
                if (this.tag == "SpecialObstacle" && iSpecialObstacle != null)
                {
                    iSpecialObstacle.OnCollision(competitorRB, contactPoint); // Call the OnCollision method on the ISpecialObstacle component with the contact point
                    return;
                }

                if (iSpecialObstacle != null)
                {
                    iSpecialObstacle.OnCollision(competitorRB, contactPoint); // Call the OnCollision method on the ISpecialObstacle component with the contact point
                }

                other.transform.GetComponent<ICompetitor>().OnCollison(); // Call the OnCollison method on the ICompetitor component of the colliding object
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (iSpecialObstacleRoutine != null)
            {
                iSpecialObstacleRoutine.OnExit(other.gameObject.GetComponent<Rigidbody>()); // Call the OnExit method on the ISpecialObstacleRoutine component with the rigidbody of the exiting object
            }
        }
    }
}
