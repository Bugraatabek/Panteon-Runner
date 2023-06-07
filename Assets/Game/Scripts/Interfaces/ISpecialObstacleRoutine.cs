using UnityEngine;

public interface ISpecialObstacleRoutine : ISpecialObstacle
{
    public void OnExit(Rigidbody rb);
}