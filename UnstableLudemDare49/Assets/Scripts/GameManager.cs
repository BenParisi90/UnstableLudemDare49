using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject introText;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject restartGameButton;
    float introTextTime = 2;
    [SerializeField] HorseDropper horseDropper;

    void Start()
    {
        showMainMenu();
        
    }

    void ResetGame()
    {
        horseDropper.canDrop = false;
    }

    public void StartGameClicked()
    {
        Debug.Log("Start game clicked");
        titleText.SetActive(false);
        startGameButton.SetActive(false);
        StartCoroutine(DisplayIntroText());
    }

    public void RestartGameClicked()
    {
        gameOverText.SetActive(false);
        restartGameButton.SetActive(false);
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
        ShowGameOverMenu();
    }

    void showMainMenu()
    {
        titleText.SetActive(true);
        gameOverText.SetActive(false);
        introText.SetActive(false);
        startGameButton.SetActive(true);
        restartGameButton.SetActive(false);
    }

    void ShowGameOverMenu()
    {
        gameOverText.SetActive(true);
        restartGameButton.SetActive(true);
    }
}