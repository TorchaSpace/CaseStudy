using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;      
    public Transform playerTransform;   
    public float minSpawnDistance = 10f; 
    public float maxSpawnDistance = 20f; 
    public float spawnDelay = 2.0f;

    public int maxPrefab = 50;
    public int spawnedPrefab;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        if(spawnedPrefab < maxPrefab)
        {
            float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

            float randomAngle = Random.Range(0f, 360f);

            Vector3 spawnPosition = playerTransform.position +
                Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward * randomDistance;

            Instantiate(prefab, spawnPosition, Quaternion.identity);

            spawnedPrefab++;
        }
    }
}
