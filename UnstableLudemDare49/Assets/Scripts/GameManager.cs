using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] HorseGameButton startGameButton;
    public GameObject mainMenu;
    [SerializeField] GameObject introText;
    float introTextTime = 2;
    [SerializeField] HorseDropper horseDropper;

    void Start()
    {
        startGameButton.clicked += StartGameClicked;
    }

    void OnDestroy()
    {
        startGameButton.clicked -= StartGameClicked;
    }

    void ResetGame()
    {
        horseDropper.canDrop = false;
    }

    void StartGameClicked()
    {
        mainMenu.SetActive(false);
        StartCoroutine(DisplayIntroText());
    }

    IEnumerator DisplayIntroText()
    {
        introText.SetActive(true);
        yield return new WaitForSeconds(introTextTime);
        introText.SetActive(false);
        horseDropper.canDrop = true;
    }
}