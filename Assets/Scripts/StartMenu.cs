using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    private bool hasStart = false;
    private Throwable throwable;
    public bool GetHasStart()
    {
        return hasStart;
    }
    private static StartMenu instance;

    void Awake()
    {
        instance = this;
        throwable = Throwable.GetInstance();
    }

    void Start()
    {
        Time.timeScale = 0f;
        throwable.enabled = false;
        startMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStart && Input.GetMouseButtonDown(0))
        {
            AudioManager.GetInstance().PlayClick();
            StartGame();
        }
    }

    void StartGame()
    {
        hasStart = true;
        Time.timeScale = 1f;
        startMenu.SetActive(false);
        throwable.enabled = true;
        instance.enabled = false;
    }
}
