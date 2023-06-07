using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Anim
{
    public class HalfDonutAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _movingStick;   // Reference to the transform of the moving stick object
        [SerializeField] private float _cycleLength = 2;   // The duration of each cycle in seconds

        void Start()
        {
            // Use DOTween library to animate the local X position of the moving stick
            // The stick moves to 0.15 units on the X-axis over the given cycle length
            // SetEase defines the easing function used for the animation (InOutSine)
            // SetLoops sets the animation to repeat indefinitely in a yoyo loop
            _movingStick.DOLocalMoveX(0.15f, _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }
    }
}

