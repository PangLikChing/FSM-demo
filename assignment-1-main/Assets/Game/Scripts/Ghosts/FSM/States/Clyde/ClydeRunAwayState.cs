using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clyde is a dumb one. He do not even know that he is in danger and will run around in circle anti-clockwise this time.
/// </summary>

public class ClydeRunAwayState : GhostBaseState
{
    int currentPoint = 0;
    [SerializeField] Vector2 firstPoint, secondPoint, thirdPoint, fourthPoint;
    Vector2[] points = new Vector2[4];
    Vector2 myPosition;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the currentPoint
        currentPoint = points.Length - 1;

        // Initialize the points
        points[0] = firstPoint;
        points[1] = secondPoint;
        points[2] = thirdPoint;
        points[3] = fourthPoint;

        // Set the first destination to the last point
        ghostController.SetMoveToLocation(points[currentPoint]);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get Inky's current position
        myPosition = ghostController.transform.position;

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

        // If Clyde's position is at the target point
        if (myPosition == points[currentPoint])
        {
            // If current point is not the first point
            if (currentPoint != 0)
            {
                // Move to the next point
                ghostController.SetMoveToLocation(points[--currentPoint]);
            }
            // If current point is the first point
            else
            {
                // Reset current point to points' size - 1
                currentPoint = points.Length - 1;
                // Move to the first point
                ghostController.SetMoveToLocation(points[currentPoint]);
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the bool IsGhost
        animator.SetBool("IsGhost", false);
    }
}
