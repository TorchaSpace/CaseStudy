using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public int damageAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }

            Destroy(gameObject); 
        }
    }


}
