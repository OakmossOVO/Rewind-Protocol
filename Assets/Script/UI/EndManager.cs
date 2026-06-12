using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Purpose:
 * Plays the ending story sequence and returns the player to the main menu.
 *
 * Attached GameObject:
 * Ending scene UI manager GameObject with a TextMeshProUGUI story text reference.
 *
 * Main responsibilities:
 * Type each ending page character by character, wait between pages, allow Space to return early,
 * switch music back to the menu track, and load the configured menu scene once.
 *
 * Inputs:
 * Story text UI reference, ending page text array, type speed, page delay, Space key, next scene name, and AudioManager.Instance.
 *
 * Outputs or effects:
 * Updates story text content, changes background music, and loads the main menu scene.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test full ending playback, Space early return, duplicate return prevention, menu music restart, and correct scene loading.
 */
public class EndingManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI storyText;

    [Header("Scene")]
    public string nextSceneName = "MainMenu";

    [Header("Timing")]
    public float typeSpeed = 0.07f;
    public float pageDelay = 2.2f;

    private bool isEndingFinished = false;

    private string[] pages =
    {
        "SIMULATION COMPLETE",

        "TEMPORAL ECHO STABILITY:\nRESTORED",

        "MEMORY TRACE:\nSYNCHRONIZED",

        "REWIND PROTOCOL:\nTERMINATED",

        "...",

        "TEMPORAL EXPERIMENT #22\n\nINITIALIZED"
    };

    void Start()
    {
        StartCoroutine(PlayEnding());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReturnToMainMenu();
        }
    }

    IEnumerator PlayEnding()
    {
        foreach (string page in pages)
        {
            yield return StartCoroutine(TypeText(page));

            yield return new WaitForSeconds(pageDelay);
        }

        ReturnToMainMenu();
    }

    IEnumerator TypeText(string text)
    {
        storyText.text = "";

        foreach (char c in text)
        {
            storyText.text += c;

            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void ReturnToMainMenu()
    {
        if (isEndingFinished)
            return;

        isEndingFinished = true;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMenuAudio();
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
