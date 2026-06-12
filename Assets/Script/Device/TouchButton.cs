using UnityEngine;

/*
 * Purpose:
 * Activates a linked door controller once when touched by the player or ghost.
 *
 * Attached GameObject:
 * Trigger button GameObject with a 2D trigger collider.
 *
 * Main responsibilities:
 * Detect valid trigger entries, lock activation after the first valid touch, and notify the target DoorController.
 *
 * Inputs:
 * Trigger collisions from objects tagged Player or Ghost, and a target DoorController reference.
 *
 * Outputs or effects:
 * Sets the touch button state on the linked DoorController and logs activation or missing reference warnings.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test player activation, ghost activation, one-time activation behavior, and missing DoorController assignment.
 */
public class TouchButton : MonoBehaviour
{
    public DoorController targetDoorController;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player") || other.CompareTag("Ghost"))
        {
            activated = true;

            if (targetDoorController != null)
            {
                targetDoorController.SetTouchButtonActive(true);
            }
            else
            {
                Debug.LogWarning("TouchButton targetDoorController is not assigned.", this);
            }

            Debug.Log("Button 2 Activated");
        }
    }
}
