using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int spikeDamage = 1;
    public float pushBackForce = 5f;
    public float minusFromSpikeCollisision = -0.5f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
                playerHealth.ringCount = 0;
                playerHealth.finalScore += minusFromSpikeCollisision;
                Debug.Log("Player ring : " +  playerHealth.ringCount);
            }

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 directionAwayFromSpike = collision.transform.position - transform.position;
                directionAwayFromSpike.Normalize(); 
                rb.AddForce(directionAwayFromSpike * pushBackForce, ForceMode2D.Impulse); 
            }

        }
    }

}
