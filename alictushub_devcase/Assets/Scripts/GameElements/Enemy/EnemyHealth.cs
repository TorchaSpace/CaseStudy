using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] Animator animator;

    private GameObject enemySpawner;
    private GameObject stats;

    public static bool isDead = false;


    private void Start()
    {
        currentHealth = maxHealth;

        enemySpawner = GameObject.Find("EnemySpawner");
        stats = GameObject.Find("Stats");
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
        stats.GetComponent<Stats>().AddKill(1);
        Destroy(gameObject);
    }

    private void Die()
    {
        gameObject.layer = 0;
        animator.SetBool("isDeath", true);
        enemySpawner.GetComponent<Spawner>().spawnedPrefab -= 1;
        StartCoroutine(DieCoroutine());
    }
}
