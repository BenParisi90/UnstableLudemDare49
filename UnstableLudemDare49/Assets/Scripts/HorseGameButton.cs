using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HorseGameButton : MonoBehaviour
{
    Collider collider;

    public UnityAction clicked;

    bool hover = false;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        hover = false;
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray,out hit, float.PositiveInfinity)) 
        {
            if(hit.collider == collider)
            {
                hover = true;
            }
        }

        if(Input.GetMouseButtonDown(0) && hover)
        {
            clicked.Invoke();
        }
    }
}
