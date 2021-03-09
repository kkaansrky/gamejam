using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePropeller : MonoBehaviour
{
    private Vector3 eulerAngles = new Vector3(15, 0, 0);
    void Update()
    {
        transform.Rotate(eulerAngles * Time.deltaTime * 75f);
    }
}
