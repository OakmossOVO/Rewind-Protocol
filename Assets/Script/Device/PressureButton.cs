using UnityEngine;

/*
 * Purpose:
 * Controls a door or door controller while the player or ghost is standing on a pressure button.
 *
 * Attached GameObject:
 * Pressure button GameObject with SpriteRenderer and a 2D trigger collider.
 *
 * Main responsibilities:
 * Track how many valid objects are on the button, switch button sprites, and notify the linked door target when pressed or released.
 *
 * Inputs:
 * Trigger enter and exit events from objects tagged Player or Ghost, button sprites, and target door references.
 *
 * Outputs or effects:
 * Changes button sprite, updates linked door activation state, and logs missing target warnings.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test player and ghost pressing together, release order, sprite switching, object count reset, and both Door and DoorController targets.
 */
public class PressureButton : MonoBehaviour
{
    public Sprite buttonOffSprite;
    public Sprite buttonOnSprite;
    public Door targetDoor;
    public DoorController targetDoorController;

    private SpriteRenderer sr;

    private int objectsOnButton = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = buttonOffSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ghost"))
        {
            objectsOnButton++;

            sr.sprite = buttonOnSprite;

            if (targetDoorController != null)
            {
                targetDoorController.SetPressureButtonActive(true);
            }
            else if (targetDoor != null)
            {
                targetDoor.SetPressureButtonActive(true);
            }
            else
            {
                Debug.LogWarning("PressureButton target door is not assigned.", this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ghost"))
        {
            objectsOnButton--;

            if (objectsOnButton <= 0)
            {
                objectsOnButton = 0;

                sr.sprite = buttonOffSprite;

                if (targetDoorController != null)
                {
                    targetDoorController.SetPressureButtonActive(false);
                }
                else if (targetDoor != null)
                {
                    targetDoor.SetPressureButtonActive(false);
                }
                else
                {
                    Debug.LogWarning("PressureButton target door is not assigned.", this);
                }
            }
        }
    }
}
