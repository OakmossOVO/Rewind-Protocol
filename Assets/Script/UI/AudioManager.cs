using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip menuAudio;
    public AudioClip gameAudio;
    public AudioClip endingAudio;
    [Range(0f, 1f)] public float musicVolume = 0.5f;
    public bool logPlaybackState = false;

    private AudioSource audioSource;
    private Coroutine loadAndPlayRoutine;

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
        ConfigureAudioSource();
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
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (clip == null)
        {
            Debug.LogError("[AudioManager] AudioClip is missing.", this);
            return;
        }

        if (audioSource == null)
        {
            Debug.LogError("[AudioManager] AudioSource is missing.", this);
            return;
        }

        ConfigureAudioSource();

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

        Debug.Log("[AudioManager] Now playing: " + clip.name);
    }

    private IEnumerator PlayWhenLoaded(AudioClip clip)
    {
        while (clip != null && clip.loadState == AudioDataLoadState.Loading)
        {
            yield return null;
        }

        loadAndPlayRoutine = null;

        if (clip == null || clip.loadState != AudioDataLoadState.Loaded)
        {
            Debug.LogWarning($"[AudioManager] BGM '{clip?.name}' failed to load. loadState={clip?.loadState}", this);
            yield break;
        }

        ConfigureAudioSource();
        audioSource.clip = clip;
        audioSource.Play();
        LogPlaybackState("Started after load", clip);
    }

    private void ConfigureAudioSource()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;

        audioSource.enabled = true;
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.mute = false;
        audioSource.volume = musicVolume;
        audioSource.spatialBlend = 0f;
    }

    private void LogPlaybackState(string action, AudioClip clip)
    {
        if (!logPlaybackState) return;

        Debug.Log($"[AudioManager] {action} BGM '{clip.name}'. isPlaying={audioSource.isPlaying}, volume={audioSource.volume}, mute={audioSource.mute}, listenerVolume={AudioListener.volume}, listenerPause={AudioListener.pause}", this);
    }
}
