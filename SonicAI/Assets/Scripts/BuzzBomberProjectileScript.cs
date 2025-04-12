using UnityEngine;

public class BuzzBomberProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; 
        Destroy(gameObject, lifetime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>()?.TakeDamage();
            Destroy(gameObject);
        }
    }
}
