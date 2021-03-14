using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Pool"))
        {
            Debug.Log("girdi");
            playerStats = GetComponent<PlayerStats>();
            GetComponent<PlayerMovement>().MoveDown();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pool"))
        {
            Debug.Log("stay");
            playerStats.addWater();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pool"))
        {
            Debug.Log("çıktı");
            GetComponent<PlayerMovement>().MoveUp();
        }
    }
}