using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helecopter : MonoBehaviour
{
    LayerMask mask;
    private Vector3 helecopterStartPoint;
    public Transform cameraPivot;
    float minAltitude;
    float minDistanceFromHelecopterToPile = 2f;
    public HorseDropper horseDropper;
    Vector3 targetPosition;

    void Start()
    {
        helecopterStartPoint = transform.position;
        mask = LayerMask.GetMask("RaycastTarget");
        minAltitude = transform.position.y;
        targetPosition = transform.position;
    }

    void Update()
    {
        if(GameManager.gameState == GameState.GAME_OVER)
        {
            return;
        }
        //move the helecopter
        float newY = Mathf.Max(helecopterStartPoint.y, horseDropper.currentPileHeight + minDistanceFromHelecopterToPile);
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray,out hit, float.PositiveInfinity, mask)) 
        {
            targetPosition = new Vector3(hit.point.x, newY, hit.point.z);
            transform.rotation = cameraPivot.rotation;
        }
       transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime); 
    }
}