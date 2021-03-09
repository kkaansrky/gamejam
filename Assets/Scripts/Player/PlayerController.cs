using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    PlayerInputController inputController;
    PlayerMovementController movementController;
    

    void Awake()
    {
        inputController = GetComponent<PlayerInputController>();
        movementController = GetComponent<PlayerMovementController>();
     

        //inputController.OnSwiped += OnSwiped;  // Action<SwipeType> kullanıyor.
        inputController.OnSwiped.AddListener(OnSwiped); // UnityEvent<SwipeType> kullanıyor. 
    }

    private void Update()
    {
        
    }

    void OnSwiped(SwipeType swipeType)
    {
        movementController.OnSwiped(swipeType);

        if (swipeType == SwipeType.Down)
        {
            
        }
    }
}
