using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats 
{
    public double coinValue;

    public void AddCoins(double value)
    {
        coinValue += value;
    }
}
