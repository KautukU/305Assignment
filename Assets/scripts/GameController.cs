using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("UI Settings")]
    public Text scoreText;
    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public GameObject pauseCanvas;

    private int score = 0;
    private playerCont player;
    private bool isPaused;
    private bool isGameOver;
    private bool isGameWin;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        player = FindObjectOfType<playerCont>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if (gameOverCanvas.activeInHierarchy || winCanvas.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        isPaused = false;
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }
    public void WinGame()
    {
        winCanvas.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("BattleSuit");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
