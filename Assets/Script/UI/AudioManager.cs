using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip menuAudio;
    public AudioClip gameAudio;
    public AudioClip endingAudio;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayMenuAudio();
    }

    public void PlayMenuAudio()
    {
        PlayMusic(menuAudio);
    }

    public void PlayGameAudio()
    {
        PlayMusic(gameAudio);
    }

    public void PlayEndingAudio()
    {
        PlayMusic(endingAudio);
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        if (audioSource.clip == clip && audioSource.isPlaying)
            return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}