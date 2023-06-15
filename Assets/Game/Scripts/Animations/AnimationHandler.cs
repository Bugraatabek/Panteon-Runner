using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Control;
using UnityEngine;

namespace Runner.Anim
{
    public class AnimationHandler : MonoBehaviour
    {
        Animator _animator;
        [SerializeField] PlayerController playerController;

        private void Awake()
        {
            _animator = GetComponent<Animator>(); 
        }

        void OnEnable()
        {
            if(playerController != null)
            {
                // Subscribe to the onMoving event in the PlayerController
                playerController.onStopMoving += IdleAnimation;
                // Subscribe to the onMoving event in the PlayerController
                playerController.onMoving += RunnerAnimation;
            }
            
            // Subscribe to the onPaintingPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += IdleAnimation;

            if(playerController != null) return;
            // Subscribe to the onRunnerPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onRunnerPhaseStart += RunnerAnimation;

            
        }
        
        private void OnDisable() 
        {
            if(playerController != null)
            {
                // Subscribe to the onStopMoving event in the PlayerController
                playerController.onStopMoving -= IdleAnimation;
                // Subscribe to the onMoving event in the PlayerController
                playerController.onMoving -= RunnerAnimation;
            }

            // Unsubscribe to the onRunnerPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onRunnerPhaseStart -= RunnerAnimation;

            // Unsubscribe to the onPaintingPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onPaintingPhaseStart -= IdleAnimation;    
        }

        private void IdleAnimation()
        {
            // Set the "Idle" parameter to true to trigger the idle animation
            _animator.SetBool("Idle", true);

            // Set the "Run" parameter to false to stop the running animation
            _animator.SetBool("Run", false);
        }

        private void RunnerAnimation()
        {
            // Set the "Idle" parameter to false to stop the idle animation
            _animator.SetBool("Idle", false);

            // Set the "Run" parameter to true to trigger the running animation
            _animator.SetBool("Run", true);
        }
    }    
}
