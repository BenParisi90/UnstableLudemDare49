using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform helecopter;
    public Camera camera;
    [SerializeField] Transform lookAtContainer;
    float pivotSpeed = 10;
    float cameraPadding = 10;
    public Vector3 pivotTarget = Vector3.zero;
    public Vector3 cameraLocalPositionTarget;

    void Start()
    {
        cameraLocalPositionTarget = lookAtContainer.localPosition;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, pivotSpeed * Time.deltaTime, 0));

        switch(GameManager.gameState)
        {
            case GameState.GAME_OVER:
                cameraLocalPositionTarget = new Vector3(0, 2,-3);
                camera.transform.LookAt(pivotTarget, Vector3.up);
                break;
            case GameState.GAMEPLAY:
            case GameState.INTRO:
                float camY = helecopter.position.y / 2;
                float camZ = (helecopter.position.y + cameraPadding) * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
                cameraLocalPositionTarget = new Vector3(0,camY,-camZ);
                camera.transform.LookAt(new Vector3(0, camera.transform.position.y, 0), Vector3.up);
                break;
            case GameState.WIN:
                cameraLocalPositionTarget = new Vector3(0, 1,-6);
                camera.transform.LookAt(pivotTarget, Vector3.up);
                break;
        }
        
        transform.position = Vector3.Lerp(transform.position, pivotTarget, .01f);
        lookAtContainer.localPosition = Vector3.Lerp(lookAtContainer.localPosition, cameraLocalPositionTarget, .01f);
    }
}
