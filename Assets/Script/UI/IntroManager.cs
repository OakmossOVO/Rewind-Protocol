using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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