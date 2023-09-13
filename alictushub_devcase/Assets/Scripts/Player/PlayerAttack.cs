using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform projectilePrefab;
    public Transform shootingPoint;
    public float attackRange = 10f;
    public float projectileSpeed = 10f;
    public float fireRate = 1f; 
    public string enemyTag = "Enemy"; 

    private float lastFireTime;

    void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRange, LayerMask.GetMask("Enemy"));

        if (enemies.Length > 0)
        {
            Transform nearestEnemy = GetNearestEnemy(enemies);

            if (nearestEnemy != null)
            {
                if (Time.time - lastFireTime >= 1f / fireRate)
                {
                    Shoot(nearestEnemy);
                    lastFireTime = Time.time;
                }
            }
        }
    }

    private Transform GetNearestEnemy(Collider[] enemies)
    {
        Transform nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Collider enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }

    private void Shoot(Transform target)
    {
        Transform newProjectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        Vector3 shootDirection = (target.position - transform.position).normalized;
        newProjectile.GetComponent<Rigidbody>().velocity = shootDirection * projectileSpeed;

        ProjectileCollisionHandler collisionHandler = newProjectile.gameObject.AddComponent<ProjectileCollisionHandler>();
        collisionHandler.enemyTag = enemyTag;
    }
}
