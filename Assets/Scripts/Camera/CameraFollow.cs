using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _cameraZ;
    private float _time, _speed = 2;

    void Update()
    {
        if (_time < 1)
        {
            _time += Time.deltaTime * _speed;
            _cameraZ = Mathf.Lerp(transform.position.z, -6f, _time);
        }
        else
        {
            _cameraZ = SalihPlayerController.GetZ() - 10.0f;
        }

        transform.position = new Vector3(0, 10f, _cameraZ);
    }
}
