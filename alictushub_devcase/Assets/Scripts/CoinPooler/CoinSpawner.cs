using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public CoinCollisionHandler prefab;
    CoinPooler cp;
    public Transform playerTransform;
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 20f;
    public float spawnDelay = 2.0f;

    public int maxPrefab = 50;
    public int spawnedPrefab;

    private void Start()
    {
        cp = new CoinPooler(prefab, transform);
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        if (spawnedPrefab < maxPrefab)
        {
            float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

            float randomAngle = Random.Range(0f, 360f);

            Vector3 spawnPosition = playerTransform.position + new Vector3(0f, 2f, 0f) +
                Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward * randomDistance;

            CoinCollisionHandler coin = cp.GetObject();

            coin.onCoinCollected += OnCoinCollected;

            coin.transform.position = spawnPosition;

            spawnedPrefab++;
        }
    }

    void OnCoinCollected(CoinCollisionHandler c)
    {
        spawnedPrefab -= 1;
        cp.ReturnObject(c);
    }
}
