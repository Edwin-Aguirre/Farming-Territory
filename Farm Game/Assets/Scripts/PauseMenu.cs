using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Written by Edwin Aguirre
    //Pressing the Esc key will pause the game and bring up a menu

    [SerializeField]
    private GameObject pauseMenuUI;

    public static bool isGamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Resume();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
