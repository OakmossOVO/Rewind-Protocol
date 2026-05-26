using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public Door targetDoor;

    public Sprite buttonOffSprite;
    public Sprite buttonOnSprite;

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

                sr.sprite = buttonOffSprite;

                targetDoor.Close();
            }
        }
    }
}