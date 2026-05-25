using System.Collections.Generic;
using UnityEngine;

public class GhostPlayback : MonoBehaviour
{
    private List<Vector3> path;
    private int index = 0;

    public void SetPath(List<Vector3> recordedPath)
    {
        path = new List<Vector3>(recordedPath);
        index = 0;
    }

    void FixedUpdate()
    {
        if (path == null || path.Count == 0) return;

        if (index < path.Count)
        {
            transform.position = path[index];
            index++;
        }
    }
}