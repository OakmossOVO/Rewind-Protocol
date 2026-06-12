using UnityEngine;

/*
 * Purpose:
 * Handles basic 2D player movement, jumping, sprite changes, facing direction, and horizontal level bounds.
 *
 * Attached GameObject:
 * Player GameObject with Rigidbody2D and SpriteRenderer components.
 *
 * Main responsibilities:
 * Read horizontal movement, apply velocity, trigger jump movement, switch between standing and running sprites,
 * flip the sprite by movement direction, and clamp the player inside configured bounds.
 *
 * Inputs:
 * Horizontal input axis, Space key, collision state, movement tuning values, sprites, and boundary values.
 *
 * Outputs or effects:
 * Updates Rigidbody2D velocity, SpriteRenderer sprite and flip state, and player transform position.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test walking left and right, jumping only while grounded, sprite switching, facing direction, and boundary clamping.
 */
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
