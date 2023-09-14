using System.Collections;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public Action<EnemyHealth> onEnemyDied;

    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] Animator animator;

    private GameObject stats;

    public static bool isDead = false;

    private void OnEnable()
    {
        currentHealth = maxHealth;
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

        onEnemyDied.Invoke(this);
    }

    private void Die()
    {
        gameObject.layer = 0;
        animator.SetBool("isDeath", true);
        StartCoroutine(DieCoroutine());
    }
}
