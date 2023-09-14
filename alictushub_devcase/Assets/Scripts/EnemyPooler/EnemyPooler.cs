using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPooler : ObjectPooler<EnemyHealth>
{
    public EnemyPooler(EnemyHealth prefab, Transform parentTransform = null) : base(prefab, parentTransform)
    {

    }
}
