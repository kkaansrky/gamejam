using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaanController : MonoBehaviour
{
    PlayerStats playerStats;
    Animator animator;
    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Pool"))
        {
            Debug.Log("girdi");
            playerStats = gameObject.GetComponent<PlayerStats>();

            //animator = gameObject.GetComponent<Animator>();
            //animator.SetTrigger("down");

            GetComponent<SalihPlayerController>().MoveDown();
        }
    }
    private void OnTriggerStay(Collider other){
        if (other.CompareTag("Pool"))
        {
            Debug.Log("stay");
            playerStats.addWater();
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Pool"))
        {
            Debug.Log("çıktı");

            GetComponent<SalihPlayerController>().MoveUp();
            //animator.SetTrigger("up");
        }
    }
}