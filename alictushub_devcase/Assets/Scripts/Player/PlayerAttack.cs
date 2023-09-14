using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    public Transform shootingPoint;
    public float attackRange = 10f;
    public float projectileSpeed = 10f;
    public float fireRate = 1f; 

    private float lastFireTime;

    void FixedUpdate()
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
        Vector3 playerFront = ((target.position + transform.position) * 1 / 4) - new Vector3(0f,0f,.2f);
        Vector3 enemyFront = ((target.position + transform.position)*3/4) + new Vector3(0f, 0f, .2f);
        

        ProjectileController newProjectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        newProjectile.StartMove(shootingPoint.position, target.position, playerFront, enemyFront);
    }
}
