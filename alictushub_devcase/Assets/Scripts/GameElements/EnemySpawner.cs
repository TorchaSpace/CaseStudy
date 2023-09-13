using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnDelay = 3f;
    [SerializeField] private static int spawnedEnemy = 0;

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player cannot found!");
            return;
        }

        StartCoroutine(SpawnEnemiesWithDelay());
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        while (true)
        {
            if(spawnedEnemy < 10)
            {
                yield return new WaitForSeconds(spawnDelay);

                Vector3 randomSpawnPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;

                randomSpawnPosition.y = 0f;

                Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);

                spawnedEnemy++;
            }
        }
    }
}
