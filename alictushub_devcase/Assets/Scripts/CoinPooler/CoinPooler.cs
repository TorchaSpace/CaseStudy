using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinPooler : ObjectPooler<CoinCollisionHandler>
{
    public CoinPooler(CoinCollisionHandler prefab, Transform parentTransform = null): base(prefab, parentTransform)
    {

    }
}
