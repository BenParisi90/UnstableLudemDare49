using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("barn hit");
        Horse horse = collider.GetComponent<Horse>();
        if(horse != null)
        {
            gameManager.WinGame();
        }
    }
}
