using UnityEngine;

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
