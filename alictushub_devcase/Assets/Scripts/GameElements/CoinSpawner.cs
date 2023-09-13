using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;      
    public Transform playerTransform;   
    public float minSpawnDistance = 10f; 
    public float maxSpawnDistance = 20f; 
    public float spawnDelay = 2.0f;

    public int maxCoin = 50;
    int coinSpawned;

    private void Start()
    {
        InvokeRepeating("SpawnCoin", spawnDelay, spawnDelay);
    }

    private void SpawnCoin()
    {
        if(coinSpawned < maxCoin)
        {
            float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

            float randomAngle = Random.Range(0f, 360f);

            Vector3 spawnPosition = playerTransform.position +
                Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward * randomDistance;

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            coinSpawned++;
        }
    }
}
