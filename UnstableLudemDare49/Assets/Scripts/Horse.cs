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

    public HorseDropper horseDropper;

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
        Horse otherHorse = collision.transform.GetComponent<Horse>();
        if(otherHorse == null || !otherHorse.touchedGround)
        {
            return;
        }
        Debug.Log("other horse");
        rigidbody.velocity = (rigidbody.velocity + otherHorse.rigidbody.velocity) / 2;
        rigidbody.angularVelocity = (rigidbody.angularVelocity + otherHorse.rigidbody.angularVelocity) / 2;
        Destroy(otherHorse.rigidbody);
        otherHorse.collected = true;
        otherHorse.transform.parent = transform;
        touchedGround = true;
        horseDropper.PlayHorseHitSound();
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
        else
        {
            rigidbody.isKinematic = false;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
        collected = false;
        touchedGround = false;
    }
}
