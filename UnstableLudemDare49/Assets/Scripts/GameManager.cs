using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject mainMenu;
    [SerializeField] HorseGameButton startGameButton;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] HorseGameButton restartGameButton;
    [SerializeField] GameObject introText;
    float introTextTime = 2;
    [SerializeField] HorseDropper horseDropper;

    void Start()
    {
        startGameButton.clicked += StartGameClicked;
        restartGameButton.clicked += RestartGameClicked;
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        introText.SetActive(false);
    }

    void OnDestroy()
    {
        startGameButton.clicked -= StartGameClicked;
        restartGameButton.clicked -= RestartGameClicked;
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

    void RestartGameClicked()
    {
        gameOverMenu.SetActive(false);
        StartCoroutine(DisplayIntroText());
    }

    IEnumerator DisplayIntroText()
    {
        introText.SetActive(true);
        yield return new WaitForSeconds(introTextTime);
        introText.SetActive(false);
        horseDropper.canDrop = true;
    }

    public void EndGame()
    {
        horseDropper.canDrop = false;
        gameOverMenu.SetActive(true);
    }
}