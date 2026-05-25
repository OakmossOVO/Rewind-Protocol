using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public Door targetDoor;

    private int objectsOnButton = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ghost"))
        {
            objectsOnButton++;
            targetDoor.Open();
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
                targetDoor.Close();
            }
        }
    }
}