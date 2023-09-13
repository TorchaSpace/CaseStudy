using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notation : MonoBehaviour
{
    private static List<string> nFormat = new List<string>();

    void Awake()
    {
        nFormat.Add("");
        nFormat.Add("K");
        nFormat.Add("M");
        nFormat.Add("B");
        nFormat.Add("T");
        nFormat.Add("Ka");
        nFormat.Add("Ke");
        nFormat.Add("Se");
        nFormat.Add("Sek");
    }

    public static string Double2dec(double value)
    {
        int num = 0;
        while (value >= 1000d)
        {
            num++;
            value /= 1000d;
        }
        return value.ToString("F1") + nFormat[num];
    }
}
