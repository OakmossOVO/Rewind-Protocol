using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GhostPlayback : MonoBehaviour
{
    private List<Vector3> path;
    private int index = 0;
    private bool playbackFinished = false;

    public bool destroyAfterPlayback = false;
    public float stayDuration = 10f;

    public TextMeshProUGUI timerText;

    public Action OnPlaybackFinished;
    public Action OnGhostExpired;

    public void SetPath(List<Vector3> recordedPath)
    {
        path = new List<Vector3>(recordedPath);
        index = 0;
        playbackFinished = false;
    }

    void FixedUpdate()
    {
        if (path == null || path.Count == 0) return;
        if (playbackFinished) return;

        if (index < path.Count)
        {
            transform.position = path[index];
            index++;
        }
        else
        {
            playbackFinished = true;
            transform.position = path[path.Count - 1];

            OnPlaybackFinished?.Invoke();

            if (destroyAfterPlayback)
            {
                StartCoroutine(ExpireAfterDelay());
            }
        }
    }

    private IEnumerator ExpireAfterDelay()
    {
        float timeLeft = stayDuration;

        if (timerText != null)
        {
            timerText.gameObject.SetActive(true);
        }

        while (timeLeft > 0)
        {
            if (timerText != null)
            {
                timerText.text = "Ghost Time Left: " + timeLeft.ToString("F1") + "s";
            }

            timeLeft -= Time.deltaTime;
            yield return null;
        }

        if (timerText != null)
        {
            timerText.text = "Ghost Time Left: 0.0s";
            timerText.gameObject.SetActive(false);
        }

        OnGhostExpired?.Invoke();
        Destroy(gameObject);
    }
}