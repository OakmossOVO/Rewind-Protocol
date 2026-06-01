using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRecorder : MonoBehaviour
{
    public GameObject ghostPrefab;
    public int maxGhosts = 1;
    public TextMeshProUGUI hintText;
    public TextMeshProUGUI ghostTimerText;

    private bool isRecording = false;
    private bool isWaitingForGhost = false;
    private bool levelCompleted = false;

    private List<Vector3> recordedPositions = new List<Vector3>();
    private List<GameObject> spawnedGhosts = new List<GameObject>();

    private Vector3 recordingStartPosition;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private PlayerMovement movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        movement = GetComponent<PlayerMovement>();

        StartRecording();
    }

    void Update()
    {
        if (isWaitingForGhost) return;

        if (Input.GetKeyDown(KeyCode.E) && isRecording)
        {
            StopRecording();
        }
    }

    void FixedUpdate()
    {
        if (isRecording)
        {
            recordedPositions.Add(transform.position);
        }
    }

    void StartRecording()
    {
        if (spawnedGhosts.Count >= maxGhosts)
        {
            Debug.Log("Ghost limit reached!");
            UpdateHintText();
            return;
        }

        recordingStartPosition = transform.position;
        recordedPositions.Clear();

        isRecording = true;

        Debug.Log("Recording started automatically");
        UpdateHintText();
    }

    void StopRecording()
    {
        isRecording = false;
        isWaitingForGhost = true;

        Debug.Log("Recording stopped");

        if (recordedPositions.Count == 0)
        {
            RespawnPlayer();
            return;
        }

        GameObject ghost = Instantiate(
            ghostPrefab,
            recordedPositions[0],
            Quaternion.identity
        );

        spawnedGhosts.Add(ghost);

        GhostPlayback playback = ghost.GetComponent<GhostPlayback>();
        playback.timerText = ghostTimerText;
        playback.SetPath(recordedPositions);

        playback.OnPlaybackFinished += () =>
        {
            RespawnPlayer();
        };

        playback.OnGhostExpired += () =>
        {
            spawnedGhosts.Remove(ghost);

            if (!levelCompleted)
            {
                ResetLevelAttempt();
            }
            else
            {
                UpdateHintText();
            }
        };

        HidePlayer();
        UpdateHintText();
    }

    void HidePlayer()
    {
        if (movement != null)
            movement.enabled = false;

        if (sr != null)
            sr.enabled = false;

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }
    }

    void RespawnPlayer()
    {
        transform.position = recordingStartPosition;

        if (rb != null)
        {
            rb.simulated = true;
            rb.velocity = Vector2.zero;
        }

        if (sr != null)
            sr.enabled = true;

        if (movement != null)
            movement.enabled = true;

        isWaitingForGhost = false;

        UpdateHintText();
    }

    void ResetLevelAttempt()
    {
        transform.position = recordingStartPosition;

        if (rb != null)
        {
            rb.simulated = true;
            rb.velocity = Vector2.zero;
        }

        if (sr != null)
            sr.enabled = true;

        if (movement != null)
            movement.enabled = true;

        recordedPositions.Clear();
        isWaitingForGhost = false;
        isRecording = false;

        StartRecording();

        Debug.Log("Level attempt reset. Recording restarted.");
    }

    void UpdateHintText()
    {
        if (hintText == null) return;

        if (isRecording)
        {
            hintText.text = "Press E to Finish Recording";
        }
        else if (isWaitingForGhost)
        {
            hintText.text = "Replaying...";
        }
        else if (spawnedGhosts.Count >= maxGhosts)
        {
            hintText.text = "Ghost Active";
        }
        else
        {
            hintText.text = "Recording Complete";
        }
    }

    public void CompleteLevel()
    {
        levelCompleted = true;
    }

    public void ResetCurrentAttempt(Vector3 resetPosition)
    {
        transform.position = resetPosition;

        if (rb != null)
        {
            rb.simulated = true;
            rb.velocity = Vector2.zero;
        }

        if (sr != null)
            sr.enabled = true;

        if (movement != null)
            movement.enabled = true;

        foreach (GameObject ghost in spawnedGhosts)
        {
            if (ghost != null)
                Destroy(ghost);
        }

        spawnedGhosts.Clear();
        recordedPositions.Clear();

        isWaitingForGhost = false;
        isRecording = false;

        StartRecording();

        UpdateHintText();

        Debug.Log("Player fell. Level attempt reset.");
    }
}