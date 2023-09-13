using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollisionHandler : MonoBehaviour
{
    GameObject coinSpawner;

    private void Start()
    {
        coinSpawner = GameObject.Find("CoinSpawner");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinSpawner.GetComponent<Spawner>().spawnedPrefab -= 1;
            Destroy(gameObject);
        }
    }
}
