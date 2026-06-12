using UnityEngine;

/*
 * Purpose:
 * Detects when the player reaches the exit portal and starts level completion.
 *
 * Attached GameObject:
 * Exit portal GameObject with a 2D trigger collider.
 *
 * Main responsibilities:
 * Prevent duplicate portal triggers, mark the player recorder as completed, and start the configured level transition.
 *
 * Inputs:
 * Player trigger collision, PlayerRecorder component on the player, and LevelTransition reference.
 *
 * Outputs or effects:
 * Stops further portal activation, completes ghost recording state, and begins the transition to the next scene.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test player-only activation, duplicate trigger prevention, recorder completion, and missing LevelTransition assignment.
 */
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
