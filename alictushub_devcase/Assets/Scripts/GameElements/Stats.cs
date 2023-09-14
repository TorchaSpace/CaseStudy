using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] private double coinValue;
    [SerializeField] private double killCount;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI killCountText;

    public void AddCoin(double value)
    {
        coinValue += value;
        coinText.text = Notation.Double2dec(coinValue);
    }

    public void AddKill(double value)
    {
        killCount += value;
        killCountText.text = Notation.Double2dec(killCount);
    }
}
