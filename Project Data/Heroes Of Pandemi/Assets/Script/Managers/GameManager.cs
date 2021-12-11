using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameStatus gameStatus;
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

    // public float firstWaveTime, secondWaveTime, thirdWaveTime, delayBetweenWave;
    // public int minSpawnEnemy, maxSpawnEnemy;
    // float timer;
    // public bool isDelayBetweenWave = false;
    // public bool isTimerRunning = true;

    public ScoreManager scoreManager;

    // Initialize Game
    void InitGame()
    {

    }

    private void Start()
    {
        //CheckingTimer();
    }
    private void Update()
    {
        ForTesting();

        // if (isTimerRunning)
        // {
        //     TimeController();
        // }
    }

    void ForTesting()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerCondition(bool win)
    {
        if (win)
        {
            Debug.Log("Player Win");
            StartCoroutine(GameEnd());
        }
        else
        {
            isGameOver = true;
            Debug.Log("Player Lose");
            StartCoroutine(GameEnd());
        }
    }

    // void TimeController()
    // {

    //     if (timer > 0)
    //     {
    //         timer -= Time.deltaTime;
    //     }
    //     else
    //     {
    //         isTimerRunning = false;
    //         //Time.timeScale = 0f;
    //     }
    //     Debug.Log(timer);

    //     if (Input.GetKeyDown(KeyCode.R))
    //     {
    //         Time.timeScale = 1;
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //     }
    // }

    // void CheckingTimer()
    // {
    //     if (gameStatus == GameStatus.FirstWave)
    //     {
    //         timer = firstWaveTime;
    //     }
    //     else if (gameStatus == GameStatus.SecondWave)
    //     {
    //         timer = secondWaveTime;
    //     }
    //     else if (gameStatus == GameStatus.ThirdWave)
    //     {
    //         timer = thirdWaveTime;
    //     }
    //     else
    //     {
    //         if (gameStatus == GameStatus.Pause)
    //         {
    //             Debug.Log("Game is pause");
    //             Time.timeScale = 0f;
    //         }
    //         else
    //         {
    //             timer = 0f;
    //             isDelayBetweenWave = true;
    //         }
    //     }

    //     isTimerRunning = true;
    // }
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
