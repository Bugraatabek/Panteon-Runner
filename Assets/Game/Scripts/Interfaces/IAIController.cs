using UnityEngine;

public interface IAIController
{
    public void Steer(Vector3 direction);
    public void StopSteering();
}