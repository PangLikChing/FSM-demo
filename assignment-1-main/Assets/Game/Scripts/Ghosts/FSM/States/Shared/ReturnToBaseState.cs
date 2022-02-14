using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State where the ghost is returning to the base
/// </summary>

public class ReturnToBaseState : GhostBaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set the moveToLocation back to base (0, 0)
        ghostController.SetMoveToLocation(ghostController.ReturnLocation);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If the ghost has return to the base
        if (new Vector2(ghostController.transform.position.x, ghostController.transform.position.y) == ghostController.ReturnLocation)
        {
            // Set the bool IsAtBase in the FSM to true
            animator.SetBool("IsAtBase", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the bool IsAtBase in the FSM to false
        animator.SetBool("IsAtBase", false);
    }
}
