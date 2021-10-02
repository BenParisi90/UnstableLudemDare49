using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helecopter : MonoBehaviour
{
    LayerMask mask;
    private Vector3 helecopterStartPoint;
    public Transform cameraPivot;

    void Start()
    {
        helecopterStartPoint = transform.position;
        mask = LayerMask.GetMask("RaycastTarget");
    }

    void Update()
    {
        //move the helecopter
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray,out hit, float.PositiveInfinity, mask)) 
        {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.rotation = cameraPivot.rotation;
        }
    }
}
