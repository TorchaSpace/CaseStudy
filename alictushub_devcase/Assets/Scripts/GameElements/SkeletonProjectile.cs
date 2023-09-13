using UnityEngine;

public class SkeletonProjectile : MonoBehaviour
{
    [SerializeField] private int damage;
    private PlayerHealth playerHealth; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}

