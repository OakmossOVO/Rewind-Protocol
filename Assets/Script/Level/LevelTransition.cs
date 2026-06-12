using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Purpose:
 * Runs the visual transition from a completed level to the next scene.
 *
 * Attached GameObject:
 * Scene transition manager GameObject referenced by the exit portal.
 *
 * Main responsibilities:
 * Disable player control, move the player into the portal, dissolve the player sprite,
 * fade the screen, and load the configured next scene.
 *
 * Inputs:
 * Player GameObject, portal Transform, fade overlay image, timing values, and next scene name.
 *
 * Outputs or effects:
 * Changes player movement, physics velocity, transform, sprite color and scale, fade overlay alpha, and scene loading.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test portal transition once per level, player movement lockout, dissolve visuals, fade timing, and loading the correct next scene.
 */
public class LevelTransition : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeOverlay;

    [Header("Timing")]
    public float moveDuration = 0.8f;
    public float dissolveDuration = 1f;
    public float fadeDuration = 0.8f;

    [Header("Scene")]
    public string nextSceneName;

    private bool isTransitioning = false;
    private Transform portalTransform;

    public void StartTransition(GameObject player, Transform portal)
    {
        if (isTransitioning) return;

        portalTransform = portal;

        StartCoroutine(TransitionRoutine(player));
    }

    private IEnumerator TransitionRoutine(GameObject player)
    {
        isTransitioning = true;

        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();

        if (movement != null)
            movement.enabled = false;

        if (rb != null)
            rb.velocity = Vector2.zero;

        // Move player to portal center
        Vector3 startPos = player.transform.position;
        Vector3 targetPos = portalTransform.position;

        float moveTimer = 0f;

        while (moveTimer < moveDuration)
        {
            moveTimer += Time.deltaTime;

            float t = moveTimer / moveDuration;

            player.transform.position =
                Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        // Dissolve effect
        Vector3 originalScale = player.transform.localScale;
        Color originalColor = sr.color;

        float dissolveTimer = 0f;

        while (dissolveTimer < dissolveDuration)
        {
            dissolveTimer += Time.deltaTime;

            float t = dissolveTimer / dissolveDuration;

            if (sr != null)
            {
                Color c = originalColor;

                c.a = Mathf.Lerp(1f, 0f, t);

                c.r = Mathf.Lerp(originalColor.r, 0.32f, t);
                c.g = Mathf.Lerp(originalColor.g, 0.70f, t);
                c.b = Mathf.Lerp(originalColor.b, 0.80f, t);

                sr.color = c;
            }

            player.transform.localScale =
                Vector3.Lerp(originalScale, Vector3.zero, t);

            yield return null;
        }

        // Screen Fade
        float fadeTimer = 0f;

        while (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;

            float t = fadeTimer / fadeDuration;

            if (fadeOverlay != null)
            {
                Color c = fadeOverlay.color;
                c.a = Mathf.Lerp(0f, 1f, t);
                fadeOverlay.color = c;
            }

            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
