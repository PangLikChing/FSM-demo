using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inky is a brave one. He chases pac man no matter where he goes
/// </summary>

public class InkyChasePlayerState : GhostBaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If pac man is currently invincible
        if (ghostController._animator.GetBool("IsGhost") == true)
        {
            // Set the bool IsGhost in the FSM to true
            animator.SetBool("IsGhost", true);
        }
        // If pac man is not invincible
        else
        {
            // Set the destination of Inky to Pac Man's position
            ghostController.SetMoveToLocation(ghostController.PacMan.position);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
