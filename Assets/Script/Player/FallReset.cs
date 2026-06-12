using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Purpose:
 * Resets the current scene after the player enters a fall or hazard trigger.
 *
 * Attached GameObject:
 * A trigger collider object placed below the level or inside a reset hazard area.
 *
 * Main responsibilities:
 * Detect the player entering the trigger, prevent duplicate resets, fade the screen overlay, and reload the active scene.
 *
 * Inputs:
 * Player trigger collisions, fade overlay image, fade duration, and current scene information.
 *
 * Outputs or effects:
 * Updates fade overlay alpha and reloads the current scene.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test player-only triggering, fade timing, duplicate trigger prevention, and correct scene reload after falling.
 */
public class FallReset : MonoBehaviour
{
    public Image fadeOverlay;
    public float fadeDuration = 0.5f;

    private bool isResetting = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isResetting) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(FallResetRoutine());
        }
    }

    private IEnumerator FallResetRoutine()
    {
        isResetting = true;

        if (fadeOverlay != null)
        {
            float timer = 0f;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                float t = timer / fadeDuration;

                Color c = fadeOverlay.color;
                c.a = Mathf.Lerp(0f, 1f, t);
                fadeOverlay.color = c;

                yield return null;
            }
        }

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
