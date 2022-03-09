using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool GameIsPaused = false;
    [SerializeField]
    public GameObject pauseUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Resume()
    { 
        pauseUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        
    }
    public void PauseGame()
    {
        pauseUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
