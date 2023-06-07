using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Anim
{
    public class RotatingStickAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _rotatingStick;    // The transform of the rotating stick
        [SerializeField] private float _cycleLength = 2f;      // The duration of each cycle in seconds

        void Start()
        {
            // Set the target rotation to a specific Euler angle (0f, 359f, 0f) 359 degrees on Y axis because FastBeyond360 doesn't work.
            Quaternion targetRotation = Quaternion.Euler(0f, 359f, 0f);

            // Rotate the rotating stick to the target rotation over the specified cycle length
            // RotateMode.LocalAxisAdd rotates the object locally around its own axis
            // SetEase defines the easing function used for the rotation (Linear)
            // SetLoops sets the rotation to repeat indefinitely with each loop restarting from the initial rotation
            _rotatingStick.DOLocalRotate(targetRotation.eulerAngles, _cycleLength, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        }
    }
}

