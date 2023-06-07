using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Anim
{
    public class RotatingPlatformAnimation : MonoBehaviour
    {
        [Tooltip("checked = rotateRight / unchecked = rotateLeft ")]
        [SerializeField] private bool rotateRight = false;   // Determines the direction of rotation

        [SerializeField] private float _cycleLength = 2f;   // The duration of each cycle in seconds

        private void Start()
        {
            if (rotateRight == true)
            {
                // Rotate the platform in the positive Z-axis direction (right) over the given cycle length
                // RotateMode.FastBeyond360 allows rotation beyond 360 degrees without additional time
                // SetEase defines the easing function used for the rotation (Linear)
                // SetLoops sets the rotation to repeat indefinitely with each loop restarting from the initial rotation
                transform.DORotate(new Vector3(0, 0, -360), _cycleLength, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
            }
            else
            {
                // Rotate the platform in the negative Z-axis direction (left) over the given cycle length
                transform.DORotate(new Vector3(0, 0, 360), _cycleLength, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
            }
        }
    }
}
