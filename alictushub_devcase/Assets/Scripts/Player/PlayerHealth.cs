using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(100);
            playerController._speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            TakeDamage(25);
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
            }

            healthBar.value = currentHealth;
        }
    }

    async private void Die()
    {
        animator.SetBool("isDeath", true);
        await Task.Delay(1000);
        gameOverScreen.SetActive(true);
        await Task.Delay(2000);
    }
}
