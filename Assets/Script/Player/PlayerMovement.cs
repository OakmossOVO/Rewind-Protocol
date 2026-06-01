using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public float leftBound = -15f;
    public float rightBound = 15f;

    public Sprite standSprite;
    public Sprite runSprite;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (move != 0)
        {
            sr.sprite = runSprite;
            sr.flipX = move < 0;
        }
        else
        {
            sr.sprite = standSprite;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(
            clampedPosition.x,
            leftBound,
            rightBound
        );

        transform.position = clampedPosition;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}