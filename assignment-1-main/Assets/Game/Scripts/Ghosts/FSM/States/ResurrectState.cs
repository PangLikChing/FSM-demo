using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectState : GhostBaseState
{
    [SerializeField] float timeNeededToResurrect = 3;

    float resurrectTimer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        // Reset the resurrect timer just to be safe
        resurrectTimer = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If the ghost has not spend timeNeededToResurrect of time in the base yet
        if (resurrectTimer < timeNeededToResurrect)
        {
            // Increase the time counter resurrectTimer
            resurrectTimer += Time.deltaTime;
        }
        else
        {
            // Set the bool IsResurrected in the FSM to true
            animator.SetBool("IsResurrected", true);

            // Set the bool IsDead in the ghost animator back to false
            ghostController._animator.SetBool("IsDead", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the bool IsResurrected in the FSM to false
        animator.SetBool("IsResurrected", false);
    }
}
