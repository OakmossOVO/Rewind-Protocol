using UnityEngine;

/*
 * Purpose:
 * Opens a door only when both pressure and touch button conditions are active.
 *
 * Attached GameObject:
 * Door GameObject controlled by multiple button inputs.
 *
 * Main responsibilities:
 * Store open and closed positions, move the door smoothly, track pressure and touch button states,
 * and decide whether the door should be open or closed.
 *
 * Inputs:
 * Open height, move speed, pressure button state, and touch button state.
 *
 * Outputs or effects:
 * Moves the door transform and updates the open or closed state based on linked button inputs.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test all button state combinations, smooth door movement, final open and closed positions, and repeated state changes.
 */
public class DoorController : MonoBehaviour
{
    public float openHeight = 3f;
    public float moveSpeed = 4f;
    public bool pressureButtonActive = false;
    public bool touchButtonActive = false;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);
    }

    void Update()
    {
        Vector3 targetPosition = isOpen ? openPosition : closedPosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }

    public void SetPressureButtonActive(bool active)
    {
        pressureButtonActive = active;
        UpdateButtonControlledState();
    }

    public void SetTouchButtonActive(bool active)
    {
        touchButtonActive = active;
        UpdateButtonControlledState();
    }

    private void UpdateButtonControlledState()
    {
        if (pressureButtonActive && touchButtonActive)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
}
