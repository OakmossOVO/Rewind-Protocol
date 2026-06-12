using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Purpose:
 * Controls the pause menu panel and pause-related navigation.
 *
 * Attached GameObject:
 * Gameplay UI manager GameObject connected to pause menu buttons.
 *
 * Main responsibilities:
 * Hide the pause panel on start, open and close the pause menu, pause and resume game time,
 * and return to the main menu with menu music restored.
 *
 * Inputs:
 * Pause panel GameObject reference, UI button click events, and AudioManager.Instance.
 *
 * Outputs or effects:
 * Toggles the pause panel, changes Time.timeScale, switches background music, and loads the MainMenu scene.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test pause panel visibility, time scale after pausing and resuming, return to menu, and missing pause panel handling.
 */
public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    public void OpenPauseMenu()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ReturnToGame()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMenuAudio();
        }

        SceneManager.LoadScene("MainMenu");
    }
}
