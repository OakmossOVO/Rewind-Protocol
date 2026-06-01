using UnityEngine;

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
            // 如果关卡宽度比摄像机视野还窄，就固定在关卡中心
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