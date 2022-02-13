using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayState : GhostBaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If the ghost is dead
        if (ghostController._animator.GetBool("IsDead") == true)
        {
            // Set the bool IsDead in the FSM to true
            animator.SetBool("IsDead", true);
        }
        // If pac man is no longer invincible
        else if (ghostController._animator.GetBool("IsGhost") == false)
        {
            // Set the bool IsDead in the FSM to true
            animator.SetBool("IsGhost", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the bool IsGhost
        animator.SetBool("IsGhost", false);
    }
}
