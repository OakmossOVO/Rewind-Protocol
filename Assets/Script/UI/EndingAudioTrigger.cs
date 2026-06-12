using UnityEngine;

/*
 * Purpose:
 * Starts the ending background audio when the ending scene begins.
 *
 * Attached GameObject:
 * Ending scene manager or audio trigger GameObject.
 *
 * Main responsibilities:
 * Find the active AudioManager singleton and request the ending audio track on Start.
 *
 * Inputs:
 * AudioManager.Instance and its ending audio configuration.
 *
 * Outputs or effects:
 * Changes the active background music to the ending track when an AudioManager exists.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test ending scene startup with and without an AudioManager instance, and confirm the ending track plays.
 */
public class EndingAudioTrigger : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayEndingAudio();
        }
    }
}
