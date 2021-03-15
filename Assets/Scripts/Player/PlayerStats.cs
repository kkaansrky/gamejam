using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    double waterSize = 0;

    public void addWater()
    {
        waterSize += 0.2;
    }

    public double getWater()
    {
        return waterSize;
    }

    public void startWater()
    {
        waterSize = 0;
    }
}
