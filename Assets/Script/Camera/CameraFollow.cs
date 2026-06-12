using UnityEngine;

/*
 * Purpose:
 * Smoothly follows the player horizontally while keeping the camera inside level bounds.
 *
 * Attached GameObject:
 * Main Camera GameObject with a Camera component.
 *
 * Main responsibilities:
 * Track a target Transform, preserve the camera's starting Y and Z positions, calculate orthographic camera limits,
 * clamp the target X position within world bounds, and smooth the camera movement.
 *
 * Inputs:
 * Target Transform, smooth speed, camera orthographic size and aspect ratio, and configured world bounds.
 *
 * Outputs or effects:
 * Updates the camera transform position each LateUpdate.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test following at both level edges, levels narrower than the camera view, missing target handling, and smooth movement speed.
 */
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    [Header("World Bounds")]
    public float leftBound = -10f;
    public float rightBound = 20f;

    private float fixedY;
    private float fixedZ;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float halfWidth = cam.orthographicSize * cam.aspect;

        float minCameraX = leftBound + halfWidth;
        float maxCameraX = rightBound - halfWidth;

        float targetX = target.position.x;

        if (minCameraX <= maxCameraX)
        {
            targetX = Mathf.Clamp(targetX, minCameraX, maxCameraX);
        }
        else
        {
            // If the level is narrower than the camera view, lock the camera to the level center.
            targetX = (leftBound + rightBound) / 2f;
        }

        Vector3 targetPosition = new Vector3(targetX, fixedY, fixedZ);

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
