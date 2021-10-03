using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] HorseDropper horseDropper; 
    void OnCollisionEnter(Collision collision)
    {
        if(GameManager.gameOver)
        {
            return;
        }
        Horse otherHorse = collision.collider.GetComponent<Horse>();
        if(otherHorse != null)
        {
            horseDropper.FreezeLiveHorses();
            Debug.Log("END GAME: " +  otherHorse.transform.position);
            gameManager.EndGame(otherHorse.transform.position);
        }
    }
}
