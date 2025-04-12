using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float bounceForce = 10f;
    private Rigidbody2D rb;
    public float scoreFromKill = 0.5f;
    public float scoreFromEnemyKill = 0f;

    [SerializeField] private Collider2D feetCollider; // Now assignable in Inspector

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PolygonCollider2D enemyHitbox = collision.GetComponent<PolygonCollider2D>();

        if (enemyHitbox != null && feetCollider.IsTouching(enemyHitbox))
        {
            Destroy(collision.gameObject); // Destroy the Buzz Bomber
            rb.velocity = new Vector2(rb.velocity.x, bounceForce); // Sonic bounces up
            scoreFromEnemyKill = scoreFromKill;
        }
    }
}
