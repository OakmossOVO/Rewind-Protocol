using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;

    public string nextSceneName = "Level_01";

    public float typeSpeed = 0.04f;
    public float pageDelay = 1.5f;

    private string[] pages =
    {
        "SYSTEM WARNING\n\nTEMPORAL ECHO STABILITY\nDECREASING",

        "CURRENT SYNCHRONIZATION:\n73%\n\nCURRENT SYNCHRONIZATION:\n48%\n\nCURRENT SYNCHRONIZATION:\n21%",

        "ADDITIONAL SYNCHRONIZATION REQUIRED\n\nPROTOCOL UPDATE:\nCOOPERATION REQUIRED"
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