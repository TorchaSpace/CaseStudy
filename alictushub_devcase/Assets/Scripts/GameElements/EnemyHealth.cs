using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] Animator animator;

    public static bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator DieCoroutine()
    {      
        yield return new WaitForSeconds(1.2f);

        Destroy(gameObject);
    }

    private void Die()
    {
        gameObject.layer = 0;
        animator.SetBool("isDeath", true);
        EnemySpawner.enemiesSpawned -= 1;
        StartCoroutine(DieCoroutine());
    }
}
