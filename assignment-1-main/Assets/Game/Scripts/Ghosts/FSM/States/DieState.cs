using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Not sure what this state is for tbh
/// </summary>

public class DieState : GhostBaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set the bool IsDead in the FSM to true
        animator.SetBool("IsDead", false);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
