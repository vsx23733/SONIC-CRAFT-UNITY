using System.Collections;
using UnityEngine;

public class BuzzBomberScript : MonoBehaviour
{
    [Header("Buzz Bomber Settings")]
    public float detectionRadius = 5f;
    public float attackDelay = 2f;
    public int damage = 1;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float fireRate = 1f;

    private bool isAttacking = false;
    private Transform player;
    private Animator animator;

    [Header("Colliders")]
    public Collider2D detectionCollider; // PolygonCollider2D (detection)
    public Collider2D contactCollider; // CircleCollider2D (contact)

    private Transform sonic;
    private float nextFireTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        animator.SetBool("IsAlive", true);
    }

    private void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) < detectionRadius && !isAttacking)
        {
            StartCoroutine(AttackSequence());
        }
    }

    private IEnumerator AttackSequence()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackDelay);

        animator.SetBool("IsAttacking", isAttacking);
        PerformAttack();

        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    private void PerformAttack()
    {
        if (Time.time >= nextFireTime)
        {
            ShootProjectile();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void ShootProjectile()
    {
        if (projectilePrefab != null && shootPoint != null && sonic != null)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            HomingProjectile homingProjectile = newProjectile.GetComponent<HomingProjectile>();
            if (homingProjectile != null)
            {
                homingProjectile.SetTarget(sonic);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sonic = collision.transform;
            StartCoroutine(AttackSequence());
        }

        if (collision == contactCollider && collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
                // Debug.Log("Sonic hit by Buzz Bomber!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = false;
        }
    }
}
