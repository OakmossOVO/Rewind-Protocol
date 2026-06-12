using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Purpose:
 * Handles main menu button actions.
 *
 * Attached GameObject:
 * Main menu UI manager GameObject connected to menu button OnClick events.
 *
 * Main responsibilities:
 * Start the game by switching music and loading the intro scene, and quit the application from the menu.
 *
 * Inputs:
 * UI button click events and AudioManager.Instance.
 *
 * Outputs or effects:
 * Loads the IntroScene, changes background music to the game track, logs quit action, and exits the application in builds.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test StartGame from the menu, missing AudioManager handling, IntroScene loading, and QuitGame behavior in a built player.
 */
public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayGameAudio();
        }

        SceneManager.LoadScene("IntroScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
