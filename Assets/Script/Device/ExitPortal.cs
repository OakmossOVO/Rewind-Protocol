using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    public LevelTransition levelTransition;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            PlayerRecorder recorder =
                other.GetComponent<PlayerRecorder>();

            if (recorder != null)
            {
                recorder.CompleteLevel();
            }

            levelTransition.StartTransition(
                other.gameObject,
                transform
            );
        }
    }
}