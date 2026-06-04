using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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