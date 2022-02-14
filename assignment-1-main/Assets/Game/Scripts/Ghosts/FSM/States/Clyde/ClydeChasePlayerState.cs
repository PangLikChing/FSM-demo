using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clyde is a dumb one. He just run around in circle and do not really "chase" the player
/// </summary>

public class ClydeChasePlayerState : GhostBaseState
{
    int currentPoint = 0;
    [SerializeField] Vector2 firstPoint, secondPoint, thirdPoint, fourthPoint;
    Vector2[] points = new Vector2[4];
    Vector2 myPosition;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the currentPoint
        currentPoint = 0;

        // Initialize the points
        points[0] = firstPoint;
        points[1] = secondPoint;
        points[2] = thirdPoint;
        points[3] = fourthPoint;

        // Set the first destination to the first point
        ghostController.SetMoveToLocation(points[0]);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        myPosition = ghostController.transform.position;

        // If pac man is currently invincible
        if (ghostController._animator.GetBool("IsGhost") == true)
        {
            // Set the bool IsGhost in the FSM to true
            animator.SetBool("IsGhost", true);
        }

        // If Clyde's position is at the target point
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
