using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    public string firePointName = "FirePoint";
    public string projectilePrefabPath = "Projectiles/ProjectilePrefab";
    public float projectileSpeed = 10f;

    private Transform firePoint;
    private GameObject projectilePrefab;
    private Transform player;

    private void Start()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child.CompareTag(firePointName))
            {
                firePoint = child;
                break;
            }
        }

        if (firePoint == null)
        {
            Debug.LogError("FirePoint not found with tag: " + firePointName);
            enabled = false;
        }

        GameObject loadedProjectilePrefab = Resources.Load<GameObject>(projectilePrefabPath);
        if (loadedProjectilePrefab == null)
        {
            Debug.LogError("ProjectilePrefab not found at path: " + projectilePrefabPath);
            enabled = false;
        }

        projectilePrefab = loadedProjectilePrefab;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Throw()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y + 2, player.position.z);

        Vector3 throwDirection = (pos - firePoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(throwDirection));

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = throwDirection * projectileSpeed;
        }

        Destroy(projectile, 10f);
    }
}
