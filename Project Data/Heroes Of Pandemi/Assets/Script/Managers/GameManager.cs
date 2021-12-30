using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameStatus gameStatus;

    public GameObject winHeader, loseHeader, gameOver, nextButton;
    public Text gameOverScore;
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public bool isGameOver = false;
    float timer;
    public bool isTimerRunning = true;

    public GameObject PauseMenuScreen;

    public ScoreManager scoreManager;

    // Initialize Game
    void InitGame()
    {

    }

    private void Start()
    {
        gameOver.SetActive(false);
        winHeader.SetActive(false);
        loseHeader.SetActive(false);
        nextButton.SetActive(false);
    }
    private void Update()
    {
        ForTesting();
    }

    void ForTesting()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerCondition(bool win)
    {
        gameOverScore.text = "999999";
        if (win)
        {
            gameOver.SetActive(true);
            winHeader.SetActive(true);
            nextButton.SetActive(true);
            Debug.Log("Player Win");
            StartCoroutine(GameEnd());
        }
        else
        {
            gameOver.SetActive(true);
            loseHeader.SetActive(true);
            isGameOver = true;
            Debug.Log("Player Lose");
            StartCoroutine(GameEnd());
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseMenuScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuScreen.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PauseMenuScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
    }

}

public enum GameStatus
{
    Pause, FirstWave, SecondWave, ThirdWave, StopWave
}
