using Runner.Control;
using UnityEngine;

namespace Runner.Anim
{
    public class PlayerAnimationHandler : AnimationHandler 
    {
        [SerializeField] PlayerController playerController;
        
        public override void OnEnable() 
        {
            // Subscribe to the onMoving event in the PlayerController
            playerController.onStopMoving += IdleAnimation;
            // Subscribe to the onMoving event in the PlayerController
            playerController.onMoving += RunnerAnimation;
            // Subscribe to the onPaintingPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += IdleAnimation;
        }

        public override void OnDisable() 
        {
            // Subscribe to the onStopMoving event in the PlayerController
            playerController.onStopMoving -= IdleAnimation;

            // Subscribe to the onMoving event in the PlayerController
            playerController.onMoving -= RunnerAnimation;

            // Unsubscribe to the onPaintingPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onPaintingPhaseStart -= IdleAnimation;    
        }
    }
}