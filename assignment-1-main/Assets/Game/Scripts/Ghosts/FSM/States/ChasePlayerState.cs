using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerState : GhostBaseState
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
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
