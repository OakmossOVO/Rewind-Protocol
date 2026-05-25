using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D doorCollider;
    private SpriteRenderer sr;

    void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        doorCollider.enabled = false;

        Color c = sr.color;
        c.a = 0.3f;
        sr.color = c;
    }

    public void Close()
    {
        doorCollider.enabled = true;

        Color c = sr.color;
        c.a = 1f;
        sr.color = c;
    }
}