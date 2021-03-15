using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatformController : MonoBehaviour
{

    [Space, SerializeField]
    GameObject endPlatform;

    [Space, SerializeField]
    ParticleSystem smoke;

    [Space, SerializeField]
    ParticleSystem fire ;
    Collider player ;


    private void OnTriggerEnter(Collider other)
    {
        player = other;
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        playerMovement.setIsGameEnd();

        GameObject environment = endPlatform.transform.parent.gameObject;
        Rigidbody rigidbody = environment.GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        
        

        CheckWater();
    }

    private void CheckWater(){
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        double water = playerStats.getWater();

        if(water < 50)
        {
            Debug.Log("Kaybettin");
        }
        else 
        {
            Debug.Log("Kazandın");
            fire.Stop();
            smoke.Play();
        }
    }
}