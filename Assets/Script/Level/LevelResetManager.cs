using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Purpose:
 * Provides a manual reset command for the active level.
 *
 * Attached GameObject:
 * Scene-level manager GameObject, usually active throughout gameplay.
 *
 * Main responsibilities:
 * Listen for the reset key, prevent overlapping reset routines, fade the screen overlay, and reload the current scene.
 *
 * Inputs:
 * R key, fade overlay image, fade duration, and current scene information.
 *
 * Outputs or effects:
 * Updates fade overlay alpha and reloads the active scene.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test pressing R during gameplay, fade timing, repeated key presses during reset, and correct scene reload.
 */
public class LevelResetManager : MonoBehaviour
{
    public Image fadeOverlay;
    public float fadeDuration = 0.5f;

    private bool isResetting = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isResetting)
        {
            StartCoroutine(ResetCurrentLevel());
        }
    }

    IEnumerator ResetCurrentLevel()
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
