using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRecorder recorder = other.GetComponent<PlayerRecorder>();

            if (recorder != null)
            {
                recorder.CompleteLevel();
            }

            Debug.Log("Level Complete!");
        }
    }
}