using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Anim
{
    public class ShiningObstacleAnimation : MonoBehaviour
    {
        [SerializeField] private float _cycleLength = 2f;             // The duration of each cycle in seconds
        [SerializeField] private float _xAxisMoveLength = 2f;        // The length of movement on the X-axis
        [SerializeField] private Transform _shiningObstacle;         // The transform of the shining obstacle
        
        [Tooltip("If unchecked, the object will move towards the negative direction on the X-axis")]
        [SerializeField] private bool _moveToPositive = true;        // Whether the object should move towards the positive direction on the X-axis

        void Start()
        {
            // Rotate the shining obstacle around the Y-axis locally by 360 degrees over the specified cycle length
            // SetLoops sets the rotation to repeat indefinitely with each loop restarting from the initial rotation
            // SetEase defines the easing function used for the rotation (Linear)
            _shiningObstacle.DOLocalRotate(new Vector3(0, 360, 0), _cycleLength, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

            // Move the object on the X-axis based on the move direction and move length
            // SetLoops sets the movement to repeat indefinitely with each loop reversing the movement direction
            // SetEase defines the easing function used for the movement (Linear)
            if (!_moveToPositive)
            {
                transform.DOMoveX(-_xAxisMoveLength, _cycleLength).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                transform.DOMoveX(_xAxisMoveLength, _cycleLength).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }
}

