using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Slider healthBar;
    [SerializeField] private EnemySpawner enemySpawner;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(100);
            playerController.enabled = false;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            
            if (currentHealth <= 0)
            {
                Die();
                enemySpawner.StopSpawning();
            }

            healthBar.value = currentHealth;
        }
    }

    private void Die()
    {
        animator.SetBool("isDeath", true);
    }
}
