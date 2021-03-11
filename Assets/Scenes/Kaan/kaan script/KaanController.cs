using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaanController : MonoBehaviour
{
    PlayerStats playerStats;
    Animator animator;
    private void OnTriggerEnter(Collider other){
        Debug.Log("girdi");
        playerStats = other.GetComponent<PlayerStats>();

        animator = other.GetComponent<Animator>();
        animator.SetTrigger("down");
    }
    private void OnTriggerStay(Collider other){
        Debug.Log("stay");
        playerStats.addWater();
    }
    private void OnTriggerExit(Collider other){
        Debug.Log("çıktı");
       
        animator.SetTrigger("up");
        

    }
    
}
