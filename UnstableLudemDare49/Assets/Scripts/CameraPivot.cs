using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform helecopter;
    public Camera camera;
    float pivotSpeed = 10;
    float cameraPadding = 4;
    void Update()
    {
        transform.Rotate(new Vector3(0, pivotSpeed * Time.deltaTime, 0));

        float camY = helecopter.position.y / 2;
        float camZ = (helecopter.position.y + cameraPadding) * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        camera.transform.localPosition = new Vector3(0,camY,-camZ);
    }
}
