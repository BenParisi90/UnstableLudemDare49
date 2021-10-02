using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject introText;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject restartGameButton;
    [SerializeField] TextMeshProUGUI heightText;
    float introTextTime = 2;
    [SerializeField] HorseDropper horseDropper;

    public static bool gameActive = false;
    float highScore = 0;

    void Start()
    {
        showMainMenu();
    }

    void Update()
    {
        highScore = Mathf.Max(highScore, horseDropper.maxHeightThisRound);
        heightText.text = "Max Height: " + horseDropper.maxHeightThisRound + "\nHigh Score: " + highScore;
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
        horseDropper.ReturnAllHorses();
        gameOverText.SetActive(false);
        restartGameButton.SetActive(false);
        StartCoroutine(DisplayIntroText());
    }

    IEnumerator DisplayIntroText()
    {
        introText.SetActive(true);
        yield return new WaitForSeconds(introTextTime);
        introText.SetActive(false);
        heightText.gameObject.SetActive(true);
        gameActive = true;
    }

    public void EndGame()
    {
        gameActive = false;
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