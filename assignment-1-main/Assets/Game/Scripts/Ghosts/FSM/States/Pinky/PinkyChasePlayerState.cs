using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pinky is a shy one.
/// She does not dare to chase pac man from a long distance from her responsible location
/// </summary>

public class PinkyChasePlayerState : GhostBaseState
{
    [SerializeField] Vector2 responsibleLocation;
    [SerializeField] float attackDistance = 3, chaseDistanceFromResponsibleLocation = 5;
    Vector2 pacManPosition, myPosition;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset pacManPosition and myPosition
        pacManPosition = new Vector2(0, 0);
        myPosition = new Vector2(0, 0);
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
            // Get pac man's current position
            pacManPosition = ghostController.PacMan.position;

            // Get Pinky's current position
            myPosition = ghostController.transform.position;

            // If the distance between Pinky and pac man is smaller than attackDistance
            // and it is not too far away from her responsible location
            if (Vector2.Distance(pacManPosition, myPosition) <= attackDistance &&
                Vector2.Distance(myPosition, responsibleLocation) <= chaseDistanceFromResponsibleLocation)
            {
                // Pinky will chase the player
                ghostController.SetMoveToLocation(pacManPosition);
            }
            // If not
            else
            {
                // Go to the responsible location
                ghostController.SetMoveToLocation(responsibleLocation);
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
