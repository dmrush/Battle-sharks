using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float detectionRadius = 10f; // Distance within which the enemy detects the player
    public float avoidanceRadius = 2f; // Distance to avoid other enemies
    public float moveSpeed = 3f; // Speed of the enemy movement

    private Transform playerTransform;

    void Start()
    {
        // Find the PlayerAI script in the scene
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Move towards the player if within detection radius
            if (distanceToPlayer < detectionRadius)
            {
                Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

                // Check for nearby enemies
                Collider[] nearbyEnemies = Physics.OverlapSphere(transform.position, avoidanceRadius);
                foreach (Collider enemy in nearbyEnemies)
                {
                    if (enemy.gameObject != gameObject) // Avoid self
                    {
                        Vector3 directionToEnemy = (enemy.transform.position - transform.position).normalized;
                        directionToPlayer += -directionToEnemy; // Adjust direction away from the enemy
                    }
                }

                // Move the enemy
                transform.position += directionToPlayer.normalized * moveSpeed * Time.deltaTime;
            }
        }
    }

    
    // This method is called when the collider attached to this GameObject
    // collides with another collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with has the tag "Enemy"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy both the player and the enemy
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the player
        }
    }

}
