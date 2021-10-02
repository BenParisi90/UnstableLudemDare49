using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    float pivotSpeed = 10;
    void Update()
    {
        transform.Rotate(new Vector3(0, pivotSpeed * Time.deltaTime, 0));
    }
}
