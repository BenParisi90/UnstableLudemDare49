using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    void OnCollisionEnter(Collision collision)
    {
        Horse otherHorse = collision.other.GetComponent<Horse>();
        if(otherHorse != null)
        {
            gameManager.EndGame();
        }
    }
}
