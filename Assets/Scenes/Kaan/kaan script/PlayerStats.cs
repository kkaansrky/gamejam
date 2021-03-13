using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float waterSize = 0;


    public void addWater(){
        waterSize += 0.2f;
        Debug.Log(waterSize);
    }
    
    
}
