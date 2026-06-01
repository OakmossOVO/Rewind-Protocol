using UnityEngine;

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
