using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button StartGameButton;
    public Button PlayAgainButton;
    public Button CreditButton;

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

        StartGameButton.onClick.AddListener(() =>
        {
            // Start UI .SetActive(false)
            // Other Game UI .SetActive(True)
            CameraController.GetInstance().enabled = true;
            Throwable.GetInstance().enabled = true;
        });

        PlayAgainButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Play");
        });

        CreditButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Credit");
        });
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        CameraController.GetInstance().enabled = false;
        Throwable.GetInstance().enabled = false;
        // Final/Result UI .SetActive(true)
        // bla bla bla
    }
}
