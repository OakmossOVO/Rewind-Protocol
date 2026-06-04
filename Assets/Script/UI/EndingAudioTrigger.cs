using UnityEngine;

public class EndingAudioTrigger : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayEndingAudio();
        }
    }
}