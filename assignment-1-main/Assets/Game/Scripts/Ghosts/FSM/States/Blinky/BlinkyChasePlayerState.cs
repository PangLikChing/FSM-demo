using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Blinky is a lasy one. He always want to sleep and he is just pretenting he is doing his job
/// </summary>

public class BlinkyChasePlayerState : GhostBaseState
{
    int currentPoint = 0;
    [SerializeField] float attackDistance, chaseDistance;
    [SerializeField] Vector2 firstPoint, secondPoint;
    Vector2[] points = new Vector2[2];
    Vector2 pacManPosition, myPosition;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the currentPoint
        currentPoint = 0;

        // Initialize the points
        points[0] = firstPoint;
        points[1] = secondPoint;

        // Set the first destination to the first point
        ghostController.SetMoveToLocation(points[0]);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get Pac Man's current position
        pacManPosition = ghostController.PacMan.position;

        // Get Blinky's current position
        myPosition = ghostController.transform.position;

        // If pac man is currently invincible
        if (ghostController._animator.GetBool("IsGhost") == true)
        {
            // Set the bool IsGhost in the FSM to true
            animator.SetBool("IsGhost", true);
        }

        // If Pac man comes into the attackDistance of Blinky
        if (Vector2.Distance(pacManPosition, myPosition) <= attackDistance)
        {
            // If Blinky is not too far from either of the patrol points
            if (Vector2.Distance(myPosition, firstPoint) <= chaseDistance || Vector2.Distance(myPosition, secondPoint) <= chaseDistance)
            {
                // Chase Pac man
                ghostController.SetMoveToLocation(pacManPosition);
            }
            // If it is too far already
            else
            {
                // Go back to patrol
                ghostController.SetMoveToLocation(points[currentPoint]);
            }
        }
        // If Blinky's position is at the target point
        else if (myPosition == points[currentPoint])
        {
            // If current point is not the final point
            if (currentPoint != points.Length - 1)
            {
                // Move to the next point
                ghostController.SetMoveToLocation(points[++currentPoint]);
            }
            // If current point is the final point
            else
            {
                // Reset current point to 0
                currentPoint = 0;
                // Move to the first point
                ghostController.SetMoveToLocation(points[currentPoint]);
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
