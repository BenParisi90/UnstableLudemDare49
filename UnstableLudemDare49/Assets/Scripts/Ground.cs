using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Horse horse = collider.GetComponent<Horse>();
        if(horse != null)
        {
            horse.touchedGround = true;
        }
    }
}
