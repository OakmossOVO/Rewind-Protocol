using UnityEngine;

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
