using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinCollisionHandler : MonoBehaviour
{
    public Action<CoinCollisionHandler> onCoinCollected;

    private GameObject stats;

    private void Start()
    {
        stats = GameObject.Find("Stats");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stats.GetComponent<Stats>().AddCoin(100);

            onCoinCollected.Invoke(this);
        }
    }
}
