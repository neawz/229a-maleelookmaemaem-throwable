using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject startMenu;
    public bool hasStart = false;

    void Start()
    {
        Time.timeScale = 0f;
        startMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStart && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        hasStart = true;
        Time.timeScale = 1f;
        startMenu.SetActive(false);
    }
}
