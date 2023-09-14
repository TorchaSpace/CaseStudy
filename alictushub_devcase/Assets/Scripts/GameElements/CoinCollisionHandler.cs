using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollisionHandler : MonoBehaviour
{
    private GameObject coinSpawner;
    private GameObject stats;

    private void Start()
    {
        coinSpawner = GameObject.Find("CoinSpawner");
        stats = GameObject.Find("Stats");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stats.GetComponent<Stats>().AddCoin(100);
            coinSpawner.GetComponent<Spawner>().spawnedPrefab -= 1;
            Destroy(gameObject);
        }
    }
}
