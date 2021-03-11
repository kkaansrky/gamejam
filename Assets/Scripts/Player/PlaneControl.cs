using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    Rigidbody rb;
    float horizontal;
    float vertical;
    Vector3 vec;
    public float speed;
    private float deltaX, deltaY;
    public float egim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
            
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector3(touchPos.x - deltaX, 0, 0));
                    break;
                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }

    }
}
