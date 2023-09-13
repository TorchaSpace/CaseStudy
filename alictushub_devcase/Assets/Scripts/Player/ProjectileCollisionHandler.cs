using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    public string enemyTag = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            Destroy(gameObject);
        }
    }
}
