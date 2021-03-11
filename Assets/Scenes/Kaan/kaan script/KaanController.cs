using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaanController : MonoBehaviour
{
    PlayerStats playerStats;
    private void OnTriggerEnter(Collider other){
        Debug.Log("girdi");
        Transform tr = other.transform;
        float y = tr.position.y-0.8f;
        other.transform.position= new Vector3(tr.position.x,y,tr.position.z);
        playerStats = other.GetComponent<PlayerStats>();

    }
    private void OnTriggerStay(Collider other){
        Debug.Log("stay");
        playerStats.addWater();

    }
    private void OnTriggerExit(Collider other){
        Debug.Log("çıktı");
        Transform tr = other.transform;
        float y = tr.position.y+0.8f;
        other.transform.position= new Vector3(tr.position.x,y,tr.position.z);

    }
    
}
