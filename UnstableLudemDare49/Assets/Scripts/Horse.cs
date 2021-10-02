using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public Rigidbody rigidbody;
    public bool collected = false;
    public bool hasCollided;

    public float maxSpin = 1;

    public List<Renderer> bodyRenderers;
    public List<Renderer> maineRenderers;

    float timeTillNotFresh = 1.2f;

    void Start()
    {
        rigidbody.angularVelocity = new Vector3(RandomSpin(),RandomSpin(),RandomSpin());
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        hasCollided = true;
        if(rigidbody == null)
        {
            return;
        }
        Debug.Log("Has Rigid body");
        Horse otherHorse = collision.transform.GetComponent<Horse>();
        if(otherHorse == null || collected)
        {
            return;
        }
        Debug.Log("other horse");
        Destroy(otherHorse.rigidbody);
        otherHorse.collected = true;
        otherHorse.transform.parent = transform;
    }

    float RandomSpin()
    {
        return Random.RandomRange(-maxSpin,maxSpin);
    }
}
