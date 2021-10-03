using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    MAIN_MENU,
    INTRO,
    GAMEPLAY,
    GAME_OVER,
    WIN
}

public class GameManager : MonoBehaviour
{
    float barnHeight = 10;
    [SerializeField] GameObject introImage;
    [SerializeField] TextMeshProUGUI introText;
    [SerializeField] AudioSource introSound;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] AudioSource gameOverSound;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject restartGameButton;
    [SerializeField] TextMeshProUGUI heightText;
    [SerializeField] GameObject winGameText;
    [SerializeField] AudioSource winGameSound;
    float introTextTime = 2;
    [SerializeField] HorseDropper horseDropper;
    [SerializeField] CameraPivot cameraPivot;
    [SerializeField] Transform barnTransform;

    public static GameState gameState = GameState.MAIN_MENU;
    float highScore = 0;

    void Start()
    {
        showMainMenu();
        barnTransform.position = new Vector3(0, barnHeight, 0);
    }

    void Update()
    {

        highScore = Mathf.Max(highScore, horseDropper.maxHeightThisRound);
        string highScoreString = highScore.ToString("f2");
        string maxHeightString = horseDropper.maxHeightThisRound.ToString("f2");
        heightText.text = "MAX HEIGHT " + maxHeightString + "\nHIGH SCORE " + highScoreString;
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
        //gameOver = false;
        gameState = GameState.GAMEPLAY;
        horseDropper.ReturnAllHorses();
        gameOverText.SetActive(false);
        restartGameButton.SetActive(false);
        cameraPivot.pivotTarget = Vector3.zero;
        barnTransform.position = new Vector3(0, barnHeight, 0);
        winGameText.SetActive(false);
        StartCoroutine(DisplayIntroText());
    }

    IEnumerator DisplayIntroText()
    {
        gameState = GameState.INTRO;
        introImage.SetActive(true);
        introText.text = barnHeight.ToString() + "M";
        introText.gameObject.SetActive(true);
        introSound.Play();
        horseDropper.maxHeightThisRound = 0;
        yield return new WaitForSeconds(introTextTime);
        introImage.SetActive(false);
        heightText.gameObject.SetActive(true);
        introText.gameObject.SetActive(false);
        gameState = GameState.GAMEPLAY;
    }

    public void EndGame(Vector3 endingHorsePosition)
    {
        horseDropper.FreezeLiveHorses();
        gameState = GameState.GAME_OVER;
        cameraPivot.pivotTarget = endingHorsePosition;
        gameOverSound.Play();
        ShowGameOverMenu();
    }

    public void WinGame()
    {
        barnHeight += 5;
        horseDropper.FreezeLiveHorses();
        gameState = GameState.WIN;
        cameraPivot.pivotTarget = barnTransform.position;
        winGameSound.Play();
        ShowWinMenu();
    }

    void showMainMenu()
    {
        gameState = GameState.MAIN_MENU;
        titleText.SetActive(true);
        gameOverText.SetActive(false);
        introImage.SetActive(false);
        startGameButton.SetActive(true);
        restartGameButton.SetActive(false);
        winGameText.SetActive(false);
        introText.gameObject.SetActive(false);
    }

    void ShowGameOverMenu()
    {
        gameOverText.SetActive(true);
        restartGameButton.SetActive(true);
    }

    void ShowWinMenu()
    {
        winGameText.SetActive(true);
        restartGameButton.SetActive(true);
    }
}