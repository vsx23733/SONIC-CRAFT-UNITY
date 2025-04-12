using UnityEngine;

public class Ring : MonoBehaviour
{
    public int ringValue = 1; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.AddRings(ringValue);   
            }

            Destroy(gameObject);
        }
    }

}
