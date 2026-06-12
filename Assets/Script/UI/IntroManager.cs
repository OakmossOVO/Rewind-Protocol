using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Purpose:
 * Plays the opening story sequence before loading the first gameplay scene.
 *
 * Attached GameObject:
 * Intro scene UI manager GameObject with a TextMeshProUGUI story text reference.
 *
 * Main responsibilities:
 * Type each intro page character by character, wait between pages, allow Space to skip, and load the configured next scene.
 *
 * Inputs:
 * Story text UI reference, intro page text array, type speed, page delay, Space key, and next scene name.
 *
 * Outputs or effects:
 * Updates story text content over time and loads the next scene.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test full intro playback, Space skip, page timing, missing story text reference, and correct first scene loading.
 */
public class IntroManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;

    public string nextSceneName = "Level_01";

    public float typeSpeed = 0.04f;
    public float pageDelay = 1.5f;

    private string[] pages =
    {
        "TEMPORAL EXPERIMENT #21\n\nINITIALIZED",

        "[WARNING]\n\nERROR 021:\nTIME DESYNCHRONIZATION DETECTED\n\nSTATUS:\nSIMULATION LOOP ........ FAILED\nMEMORY TRACE ........... FOUND\nREPLAY MODULE .......... RESTORED\nTEMPORAL ECHO .......... GENERATED",

        "SIMULATION DIRECTIVE\n\nTO ESCAPE THE SIMULATION,\nYOU MUST COOPERATE WITH YOUR PAST SELF.",

        "REWIND PROTOCOL\n\nONLINE"
    };

    private Coroutine introRoutine;

    void Start()
    {
        introRoutine = StartCoroutine(PlayIntro());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    IEnumerator PlayIntro()
    {
        foreach (string page in pages)
        {
            yield return StartCoroutine(TypeText(page));
            yield return new WaitForSeconds(pageDelay);
        }

        SceneManager.LoadScene(nextSceneName);
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
}
