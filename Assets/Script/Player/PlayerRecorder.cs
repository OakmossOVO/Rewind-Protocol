using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRecorder : MonoBehaviour
{
    public GameObject ghostPrefab;
    public int maxGhosts = 1;
    public TextMeshProUGUI hintText;

    private bool isRecording = false;
    private List<Vector3> recordedPositions = new List<Vector3>();
    private List<GameObject> spawnedGhosts = new List<GameObject>();

    void Start()
    {
        UpdateHintText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isRecording)
                StartRecording();
            else
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
            return;
        }

        recordedPositions.Clear();
        isRecording = true;
        Debug.Log("Recording started");
        UpdateHintText();
    }

    void StopRecording()
    {
        isRecording = false;
        Debug.Log("Recording stopped");

        if (recordedPositions.Count == 0) return;

        GameObject ghost = Instantiate(
            ghostPrefab,
            recordedPositions[0],
            Quaternion.identity
        );

        spawnedGhosts.Add(ghost);

        GhostPlayback playback = ghost.GetComponent<GhostPlayback>();
        playback.SetPath(recordedPositions);

        UpdateHintText();
    }

    void UpdateHintText()
    {
        if (hintText == null) return;

        if (isRecording)
        {
            hintText.text = "Recording...";
        }
        else if (spawnedGhosts.Count >= maxGhosts)
        {
            hintText.text = "Ghost Created";
        }
        else
        {
            hintText.text = "Press E to Record";
        }
    }
}