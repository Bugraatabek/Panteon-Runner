using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _fJoystick;  // Reference to the floating joystick used for player control
        [SerializeField] private float _runSpeed = 2f; // Speed at which the player runs forward
        [SerializeField] private float _moveSideSpeed = 20f; // Speed at which the player moves sideways
        [SerializeField] private bool _shouldRun = false; // Flag indicating whether the player should be running
        public event Action onMoving;
        public event Action onStopMoving;

        private void OnEnable()
        {
            Singleton.Instance.PhaseManager.onRunnerPhaseStart += StartRunnerControls; // Subscribe to the onRunnerPhaseStart event
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += StopRunnerControls; // Subscribe to the onPaintingPhaseStart event
        }

        private void OnDisable() 
        {
            Singleton.Instance.PhaseManager.onRunnerPhaseStart -= StartRunnerControls; // Unsubscribe to the onRunnerPhaseStart event
            Singleton.Instance.PhaseManager.onPaintingPhaseStart -= StopRunnerControls; // Unsubscribe to the onPaintingPhaseStart event
        }

        private void StopRunnerControls()
        {
            _shouldRun = false; // Disable player running
        }

        private void StartRunnerControls()
        {
            _shouldRun = true; // Enable player running
        }

        private void FixedUpdate()
        {
            if (!_shouldRun) return; // If player should not run, exit the method
            onStopMoving();
            // Move the player vertically based on joystick input
            if(_fJoystick.Vertical != 0)
            {
                onMoving?.Invoke();
                transform.Translate(Vector3.forward * _runSpeed * _fJoystick.Vertical  * Time.fixedDeltaTime);
            }

            // Move the player horizontally based on joystick input
            if (_fJoystick.Horizontal != 0)
            {
                onMoving?.Invoke();
                transform.Translate(Vector3.right * _moveSideSpeed * _fJoystick.Horizontal * Time.fixedDeltaTime);
            }
            
        }
    }
}
