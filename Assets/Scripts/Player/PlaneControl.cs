using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    private Touch touch;
    private float speed;

    public static float _z;

    void Start(){
        speed=0.01f;

    }

    void FixedUpdate(){
        
        _z=transform.position.z;
        transform.Translate(Vector3.forward*5*Time.deltaTime);

        if(Input.touchCount > 0){
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved){
                if(touch.deltaPosition.x >0){
                    
                }
                transform.position = new Vector3(Mathf.Clamp((transform.position.x+touch.deltaPosition.x*speed),-2.5f,2.5f),4,transform.position.z);
            }
        }
        

    }


    public static float GetZ()
    {
        return PlaneControl._z;
    }
    
}
