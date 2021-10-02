using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform helecopter;

    public GameObject horsePrefab;

    private Vector3 helecopterStartPoint;

    void Start()
    {
        helecopterStartPoint = helecopter.transform.position;
    }

    void Update()
    {
        //move the helecopter
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray,out hit)) 
        {
            Debug.Log(hit.point);
            helecopter.transform.position = new Vector3(hit.point.x, helecopterStartPoint.y, helecopterStartPoint.z);
        }

        //spawn a horse when we click
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click mouse");
            Instantiate(horsePrefab, helecopter.position, Quaternion.identity);
        }
    }
}
