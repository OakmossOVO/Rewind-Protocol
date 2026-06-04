using UnityEngine;
using UnityEngine.SceneManagement;

public class FallReset : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRecorder recorder = other.GetComponent<PlayerRecorder>();

            if (recorder != null)
            {
                recorder.ResetCurrentAttempt();
            }
            else
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.buildIndex);
            }
        }
    }
}
