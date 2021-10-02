using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public Rigidbody rigidbody;
    public bool collected = false;
    public bool touchedGround = false;

    public float maxSpin = 1;

    public List<Renderer> bodyRenderers;
    public List<Renderer> maineRenderers;

    float timeTillNotFresh = 1.2f;
    public Collider groundCollider;

    void Start()
    {
        rigidbody.angularVelocity = new Vector3(RandomSpin(),RandomSpin(),RandomSpin());
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(rigidbody == null || collected)
        {
            return;
        }
        Debug.Log("Has Rigid body");
        if(collision.other == groundCollider)
        {
            touchedGround = true;
        }
        Horse otherHorse = collision.transform.GetComponent<Horse>();
        if(otherHorse == null || !otherHorse.touchedGround)
        {
            return;
        }
        Debug.Log("other horse");
        Destroy(otherHorse.rigidbody);
        otherHorse.collected = true;
        otherHorse.transform.parent = transform;
        touchedGround = true;
    }

    float RandomSpin()
    {
        return Random.RandomRange(-maxSpin,maxSpin);
    }

    public void ResetProperties()
    {
        if(rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        collected = false;
        touchedGround = false;
    }
}
