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
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject restartGameButtonLose;
    [SerializeField] GameObject restartGameButtonWin;
    [SerializeField] TextMeshProUGUI heightText;
    [SerializeField] GameObject winGameText;
    float introTextTime = 2.8f;
    [SerializeField] HorseDropper horseDropper;
    [SerializeField] CameraPivot cameraPivot;
    [SerializeField] Transform barnTransform;
    [SerializeField] MusicManager musicManager;
    [SerializeField] ParticleSystem winParticleSystem;

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
        string highScoreString = metersToHands(highScore).ToString("f2");
        string maxHeightString = metersToHands(horseDropper.maxHeightThisRound).ToString("f2");
        heightText.text = "HANDS: " + maxHeightString + "\nHIGH SCORE: " + highScoreString;
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
        restartGameButtonLose.SetActive(false);
        restartGameButtonWin.SetActive(false);
        cameraPivot.pivotTarget = Vector3.zero;
        barnTransform.position = new Vector3(0, barnHeight, 0);
        winGameText.SetActive(false);
        winParticleSystem.Stop();
        StartCoroutine(DisplayIntroText());
    }

    IEnumerator DisplayIntroText()
    {
        gameState = GameState.INTRO;
        introImage.SetActive(true);
        introText.text = barnHeight.ToString() + "HANDS";
        introText.gameObject.SetActive(true);
        musicManager.PlayMusic(musicManager.IntroMusic);
        horseDropper.maxHeightThisRound = 0;
        yield return new WaitForSeconds(introTextTime);
        introImage.SetActive(false);
        heightText.gameObject.SetActive(true);
        introText.gameObject.SetActive(false);
        gameState = GameState.GAMEPLAY;
        musicManager.PlayMusic(musicManager.GameplayMusic);
    }

    public void EndGame(Vector3 endingHorsePosition)
    {
        horseDropper.FreezeLiveHorses();
        gameState = GameState.GAME_OVER;
        cameraPivot.pivotTarget = endingHorsePosition;
        musicManager.PlayMusic(musicManager.GameOverMusic);
        ShowGameOverMenu();
    }

    public void WinGame()
    {
        barnHeight += 5;
        horseDropper.FreezeLiveHorses();
        gameState = GameState.WIN;
        cameraPivot.pivotTarget = barnTransform.position;
        musicManager.PlayMusic(musicManager.WinGameMusic);
        winParticleSystem.Play();
        ShowWinMenu();
    }

    void showMainMenu()
    {
        gameState = GameState.MAIN_MENU;
        titleText.SetActive(true);
        gameOverText.SetActive(false);
        introImage.SetActive(false);
        startGameButton.SetActive(true);
        restartGameButtonLose.SetActive(false);
        restartGameButtonWin.SetActive(false);
        winGameText.SetActive(false);
        introText.gameObject.SetActive(false);
    }

    void ShowGameOverMenu()
    {
        gameOverText.SetActive(true);
        StartCoroutine(ShowButtonAfterTime(restartGameButtonLose));
    }

    void ShowWinMenu()
    {
        winGameText.SetActive(true);
        StartCoroutine(ShowButtonAfterTime(restartGameButtonWin));
    }

    IEnumerator ShowButtonAfterTime(GameObject button)
    {
        yield return new WaitForSeconds(2f);
        button.SetActive(true);
    }

    float metersToHands(float meters)
    {
        return meters * .1016f;
    }
}