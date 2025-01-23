using UnityEngine;

public class MoveTowardsPlayerWithRigidbody : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRange = 10f;
    private Rigidbody2D rb;
    private GameObject playerChildren;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerChildren = GameObject.FindGameObjectWithTag("PlayerChildren");

        if (playerChildren != null)
        {
            float distance = Vector2.Distance(transform.position, playerChildren.transform.position);
            if (distance < detectionRange)
            {
                Vector2 direction = (playerChildren.transform.position - transform.position).normalized;
                rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerChildren"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
