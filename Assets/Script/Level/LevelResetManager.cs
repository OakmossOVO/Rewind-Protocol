using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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