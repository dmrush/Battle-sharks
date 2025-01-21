using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothSpeed = 0.125f; // Speed of the camera's smooth movement
    public Vector3 offset; // Offset from the target position

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position based on the target's position and the offset
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.y = transform.position.y; // Freeze the Y-axis

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
