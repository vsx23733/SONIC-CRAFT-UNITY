using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int ringCount = 0;
    public float finalScore = 0f;
    public int maxHealth = 1;


    // For score management
    public float scoreFromRing = 0.05f;
    public float scoreFromMapProgression = 5f;
    private float lastXPosition;
    private float alphaX = 1000000000f;
    private float deltaMultiplier = 100000000f;

    private float scoreAccumulator = 0f;
    private float scoreUpdateInterval = 1f;
    private float timeSinceLastUpdate = 0f;


    private bool isInvincible = false;
    // private bool win = false;
    public float invincibilityDuration = 2f; // Time before Sonic can be hit again


    public GameObject droppedRing;
    // private UIManager GameUIManager;
    public Transform player;
    public SonicController controller;
    public PlayerAttack attackManager;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        // Accumulate score from progression and rings
        scoreAccumulator += GetScoringForward() + GetScoringFromEnemy();

        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= scoreUpdateInterval)
        {
            finalScore += scoreAccumulator;
            scoreAccumulator = 0f;
            timeSinceLastUpdate = 0f;
            UpdateUI();
        }
    }

    public float GetScoringForward()
    {
        if (player != null)
        {
            float deltaX = player.position.x - lastXPosition;
            deltaX *= deltaMultiplier;
            lastXPosition = player.position.x;

            if (deltaX > 0)
            {
                return deltaX * (scoreFromMapProgression / alphaX);
            }
            else if (deltaX < 0)
            {
                return deltaX * (scoreFromMapProgression / alphaX);
            }
        }
        return 0f;
    }

    public float GetScoringFromEnemy()
    {
        if (attackManager != null)
        {
            return attackManager.scoreFromEnemyKill;
        }
        return 0f;
    }

    public void AddRings(int amount)
    {
        ringCount += amount;
        scoreAccumulator += amount * scoreFromRing;
    }

    public void TakeDamage()
    {
        if (isInvincible) return;

        if (ringCount > 0)
        {
            DropRings();
            StartCoroutine(InvincibilityFrames());
        }
        else
        {
            Die();
        }
    }

    void DropRings()
    {
        int numRingsToDrop = Mathf.Min(ringCount, 10);
        ringCount -= numRingsToDrop;
        finalScore -= (scoreFromRing * numRingsToDrop);

        for (int i = 0; i < numRingsToDrop; i++)
        {
            Vector2 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f), 0);
            GameObject ring = Instantiate(droppedRing, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = ring.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(Random.Range(-3f, 3f), Random.Range(2f, 5f));
            }
        }

        UpdateUI();
        Debug.Log("Dropped " + numRingsToDrop + " rings!");
    }

    IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Sonic Died! Restarting...");
        controller.isAlive = true;
    }

    void UpdateUI()
    {
        Debug.Log("Rings: " + ringCount);
        Debug.Log("Score: " + finalScore);

    }
}