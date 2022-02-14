using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inky is a brave one.
/// He tries to keep up with pac man even when he was meant to run away
/// </summary>

public class InkyRunAwayState : GhostBaseState
{
    [SerializeField] float comfortableDistance = 4, maxWorldX, minWorldX, maxWorldY, minWorldY, gridDistance;
    Vector2 pacManPosition, myPosition;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset pacManPosition and myPosition
        pacManPosition = new Vector2(0, 0);
        myPosition = new Vector2(0, 0);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get pac man's current position
        pacManPosition = ghostController.PacMan.position;

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

        // If the distance between Pac Man and Inky is too close
        if (Vector2.Distance(pacManPosition, myPosition) <= comfortableDistance)
        {
            // Inky will move away from Pac Man

            // Get a temporary targetX and targetY
            float targetX = 0, targetY = 0;

            // If Pac man is coming from the left and Pinky is not at the right edge of the map
            if (pacManPosition.x < myPosition.x && myPosition.x != maxWorldX)
            {
                // Move to the right by gridDistance amount
                targetX = myPosition.x + gridDistance;
            }
            // If Pac Man is coming from a straight line
            else if (pacManPosition.x == myPosition.x)
            {
                // If Pac man is coming from vertical
                if (pacManPosition.y != myPosition.y)
                {
                    // If Inky is at the right edge of the map
                    if (myPosition.x == maxWorldX)
                    {
                        // Move to the left by gridDistance
                        targetX = myPosition.x - gridDistance;
                    }
                    // if Inky is at the left edge of the map
                    else if (myPosition.x == minWorldX)
                    {
                        // Move to the right by gridDistance
                        targetX = myPosition.x + gridDistance;
                    }
                    // Default
                    else
                    {
                        // Move to the right by gridDistance
                        targetX = myPosition.x + gridDistance;
                    }
                }
            }
            // If Pac man is coming from the right and Inky is not at the left edge of the map
            else if (pacManPosition.x > myPosition.x && myPosition.x != minWorldX)
            {
                // Move to the left by gridDistance amount
                targetX = myPosition.x - gridDistance;
            }
            // Else
            else
            {
                // Stay at the X coordinate
                targetX = myPosition.x;
            }

            // If Pac man is coming from the bottom and Inky is not at the top edge of the map
            if (pacManPosition.y < myPosition.y && myPosition.y != maxWorldY)
            {
                // Move up by gridDistance amount
                targetY = myPosition.y + gridDistance;
            }
            // If Pac Man is coming from a straight line
            else if (pacManPosition.y == myPosition.y)
            {
                // If Pac man is coming from horizontal
                if (pacManPosition.x != myPosition.x)
                {
                    // If Inky is at the top edge of the map
                    if (myPosition.y == maxWorldY)
                    {
                        // Move down by gridDistance
                        targetX = myPosition.y - gridDistance;
                    }
                    // if Inky is at the bottom edge of the map
                    else if (myPosition.y == minWorldY)
                    {
                        // Move up by gridDistance
                        targetX = myPosition.y + gridDistance;
                    }
                    // Default
                    else
                    {
                        // Move up by gridDistance
                        targetX = myPosition.y + gridDistance;
                    }
                }
            }
            // If Pac man is coming from the top and Inky is not at the bottom edge of the map
            else if (pacManPosition.y > myPosition.y && myPosition.y != minWorldY)
            {
                // Move down by gridDistance amount
                targetY = myPosition.y - gridDistance;
            }
            // Else
            else
            {
                // Stay at the Y coordinate
                targetY = myPosition.y;
            }

            // Move to target location
            Vector2 targetLocation = new Vector2(targetX, targetY);
            ghostController.SetMoveToLocation(targetLocation);
        }
        // If not
        else
        {
            // Inky will continue the chase Pac Man
            ghostController.SetMoveToLocation(pacManPosition);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the bool IsGhost
        animator.SetBool("IsGhost", false);
    }
}
