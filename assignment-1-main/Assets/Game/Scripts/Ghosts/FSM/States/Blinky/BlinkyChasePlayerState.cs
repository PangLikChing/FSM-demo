using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Blinky is a lasy one. He always want to sleep and he is just pretenting he is doing his job
/// </summary>

public class BlinkyChasePlayerState : GhostBaseState
{
    int currentPoint = 0;
    [SerializeField] Vector2 firstPoint, secondPoint;
    Vector2[] points = new Vector2[2];
    Vector2 myPosition;

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
        // Get Blinky's current position
        myPosition = ghostController.transform.position;

        // If pac man is currently invincible
        if (ghostController._animator.GetBool("IsGhost") == true)
        {
            // Set the bool IsGhost in the FSM to true
            animator.SetBool("IsGhost", true);
        }

        // If Blinky's position is at the target point
        if (myPosition == points[currentPoint])
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
