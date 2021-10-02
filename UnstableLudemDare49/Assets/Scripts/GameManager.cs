using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    LayerMask mask;
    public Transform helecopter;

    public GameObject horsePrefab;

    private Vector3 helecopterStartPoint;

    public Transform cameraPivot;

    void Start()
    {
        helecopterStartPoint = helecopter.transform.position;
        mask = LayerMask.GetMask("RaycastTarget");
    }

    void Update()
    {
        //move the helecopter
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray,out hit, float.PositiveInfinity, mask)) 
        {
            helecopter.transform.position = new Vector3(hit.point.x, helecopter.transform.position.y, hit.point.z);
            helecopter.transform.rotation = cameraPivot.rotation;
        }

        //spawn a horse when we click
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click mouse");
            Instantiate(horsePrefab, helecopter.position, Random.rotation);
        }
    }
}
