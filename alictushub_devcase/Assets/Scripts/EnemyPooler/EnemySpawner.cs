using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyHealth prefab;
    EnemyPooler ep;
    public Transform playerTransform;
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 20f;
    public float spawnDelay = 2.0f;

    public int maxPrefab = 50;
    public int spawnedPrefab;

    private void Start()
    {
        ep = new EnemyPooler(prefab, transform);
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        if (spawnedPrefab < maxPrefab)
        {
            float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

            float randomAngle = Random.Range(0f, 360f);

            Vector3 spawnPosition = (playerTransform.position + new Vector3(0f, 3f, 0f)) +
                Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward * randomDistance;

            EnemyHealth enemy = ep.GetObject();

            enemy.onEnemyDied += OnEnemyDied;

            enemy.transform.position = spawnPosition;

            spawnedPrefab++;
        }
    }

    void OnEnemyDied(EnemyHealth e)
    {
        spawnedPrefab -= 1;
        ep.ReturnObject(e);
    }
}
