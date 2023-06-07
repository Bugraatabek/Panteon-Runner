using UnityEngine;

public interface ISpecialObstacle
{
    public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint);
}