using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Start")]
    public StartMenu startMenu;

    [Header("Tutorial")]
    public GameObject tutorialUI;

    [Header("Game Over")]
    public Button PlayAgainButton;
    public Button CreditButton;
    public TextMeshProUGUI RoundScoreText;
    public TextMeshProUGUI HighScoreText;

    [Header("Score")]
    public GameObject ScoreUI;
    public TextMeshProUGUI ScoreText;

    private bool onceStarted = true;
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // PlayAgainButton.onClick.AddListener(() =>
        // {
        //     Time.timeScale = 1f;
        //     SceneManager.LoadScene("Main");
        // });

        // CreditButton.onClick.AddListener(() =>
        // {
        //     Time.timeScale = 1f;
        //     SceneManager.LoadScene("Credit");
        // });
    }

    void Update()
    {
        if (startMenu.GetHasStart() && onceStarted)
        {
            ScoreUI.SetActive(true);
            tutorialUI.SetActive(true);
            CameraController.GetInstance().enabled = true;
            Throwable.GetInstance().enabled = true;
            onceStarted = false;
        }

        if (CameraController.GetInstance().cameraFollow)
        {
            ScoreText.text = $"{Throwable.GetInstance().GetDistance():F1} m";
        }
    }
    public void GameOver()
    {
        SaveHighScore();
        Time.timeScale = 0f;
        CameraController.GetInstance().enabled = false;
        Throwable.GetInstance().enabled = false;
        
        ScoreUI.SetActive(false);
        // Final/Result UI .SetActive(true)
        RoundScoreText.text = $"Round Score: {PlayerPrefs.GetFloat("RoundScore", 0):F1} m";
        HighScoreText.text = $"High Score: {PlayerPrefs.GetFloat("HighScore", 0):F1} m";
    }

    public void MiniTutorialDone()
    {
        tutorialUI.SetActive(false);
    }

    public void SaveHighScore()
    {
        float roundScore = Throwable.GetInstance()?.GetDistance() ?? 0;
        PlayerPrefs.SetFloat("RoundScore", roundScore);

        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (roundScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", roundScore);
        }
        PlayerPrefs.Save();
    }
}
