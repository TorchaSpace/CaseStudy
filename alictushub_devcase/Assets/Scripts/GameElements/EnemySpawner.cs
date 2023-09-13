using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnDelay = 2;
    [SerializeField] private int maxEnemiesToSpawn = 8;

    public static int enemiesSpawned = 0;
    private Coroutine spawningCoroutine;

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player cannot be found!");
            return;
        }

        StartSpawning();
    }

    private void StartSpawning()
    {
        if (spawningCoroutine == null)
        {
            spawningCoroutine = StartCoroutine(SpawnEnemiesWithDelay());
        }
    }

    public void StopSpawning()
    {
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
            spawningCoroutine = null;
        }
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        while (true)
        {
            while (enemiesSpawned < maxEnemiesToSpawn)
            {
                yield return new WaitForSeconds(spawnDelay);

                Vector3 randomSpawnPosition = playerTransform.position + Random.insideUnitSphere * spawnRadius;
                randomSpawnPosition.y = 0f;

                Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);

                enemiesSpawned++;
            }

            while (enemiesSpawned >= maxEnemiesToSpawn)
            {
                yield return null;

                if (enemiesSpawned < maxEnemiesToSpawn)
                {
                    break;
                }
            }
        }
    }
}
