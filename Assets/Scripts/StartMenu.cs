using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    private bool hasStart = false;
    public bool GetHasStart()
    {
        return hasStart;
    }
    private static StartMenu instance;

    void Awake()
    {
        instance = this;
    }

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

        instance.enabled = false;
    }
}
