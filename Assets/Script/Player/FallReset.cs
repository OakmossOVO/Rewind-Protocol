using UnityEngine;

public class FallReset : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRecorder recorder = other.GetComponent<PlayerRecorder>();

            if (recorder != null)
            {
                recorder.ResetCurrentAttempt(respawnPoint.position);
            }
            else
            {
                other.transform.position = respawnPoint.position;

                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }
}