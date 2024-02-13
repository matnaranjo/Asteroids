using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the player's transform
    public float smoothSpeed = 0.125f; // Adjust the camera follow speed

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
