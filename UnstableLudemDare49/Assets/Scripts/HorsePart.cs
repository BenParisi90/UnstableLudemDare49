using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePart : MonoBehaviour
{
    public Horse horse;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        Horse otherHorse = collision.transform.GetComponentInParent<Horse>();
        if(otherHorse == null)
        {
            return;
        }
        Debug.Log("other horse");
        Destroy(horse.rigidbody);
        horse.transform.parent = otherHorse.transform;
    }
}
