using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnDelay = 3f;
    [SerializeField] private int maxEnemiesToSpawn = 10;

    public static int enemiesSpawned = 0;

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player cannot be found!");
            return;
        }

        StartCoroutine(SpawnEnemiesWithDelay());
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        while (enemiesSpawned < maxEnemiesToSpawn)
        {
            yield return new WaitForSeconds(spawnDelay);

            Vector3 randomSpawnPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;
            randomSpawnPosition.y = 0f;

            Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);

            enemiesSpawned++;

            if (enemiesSpawned >= maxEnemiesToSpawn)
            {
                Debug.Log("Maximum number of enemies spawned.");
                break; // Exit the loop.
            }
        }
    }
}
