using UnityEngine;

public class SmoothFollowPlayer : MonoBehaviour
{
    public float followDistance = 2.0f;
    public float separationDistance = 1.5f;
    public float speed = 2.0f;
    public float smoothTime = 0.3f;

    private Transform player;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 desiredPosition = player.position + (transform.position - player.position).normalized * followDistance;
        Vector3 separationForce = CalculateSeparationForce();
        Vector3 targetPosition = desiredPosition + separationForce;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private Vector3 CalculateSeparationForce()
    {
        Vector3 force = Vector3.zero;
        SmoothFollowPlayer[] neighbors = FindObjectsOfType<SmoothFollowPlayer>();

        foreach (SmoothFollowPlayer neighbor in neighbors)
        {
            if (neighbor != this)
            {
                float distance = Vector3.Distance(transform.position, neighbor.transform.position);
                if (distance < separationDistance)
                {
                    force += (transform.position - neighbor.transform.position).normalized * (separationDistance - distance);
                }
            }
        }
        return force;
    }
}
