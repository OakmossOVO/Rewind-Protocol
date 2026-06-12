using UnityEngine;

/*
 * Purpose:
 * Opens or closes a simple vertical door controlled by a pressure button.
 *
 * Attached GameObject:
 * Door GameObject that should move upward when opened and return to its starting position when closed.
 *
 * Main responsibilities:
 * Store closed and open positions, move toward the current target position, and respond to pressure button state changes.
 *
 * Inputs:
 * Open height, move speed, and pressure button activation state.
 *
 * Outputs or effects:
 * Moves the door transform between closed and open positions.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test opening and closing from the assigned button, movement speed, final positions, and repeated activation changes.
 */
public class Door : MonoBehaviour
{
    public float openHeight = 3f;
    public float moveSpeed = 4f;
    public bool pressureButtonActive = false;

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
        if (pressureButtonActive)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
}
