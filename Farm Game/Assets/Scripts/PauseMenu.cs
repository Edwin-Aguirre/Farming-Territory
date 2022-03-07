using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    //Written by Edwin Aguirre
    //Pressing the Esc key will pause the game and bring up a menu

    [SerializeField]
    public GameObject pauseMenuUI;
    [SerializeField]
    private GameObject controlsMenu;
    [SerializeField]
    private GameObject keyboardMenu;
    [SerializeField]
    private GameObject controllerMenu;

    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject controlsResumeButton;
    [SerializeField]
    private GameObject keyboardButton;
    [SerializeField]
    private GameObject controllerButton;

    public static bool isGamePaused = false;

    public static PauseMenu instance;

    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause/Back"))
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
        controlsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
        EventSystem.current.firstSelectedGameObject = resumeButton;
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

    public void ControlsMenu()
    {
        controlsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsResumeButton);
        EventSystem.current.firstSelectedGameObject = controlsResumeButton;
        pauseMenuUI.SetActive(false);
        keyboardButton.SetActive(true);
        controllerButton.SetActive(true);
        keyboardMenu.SetActive(false);
        controllerMenu.SetActive(false);

    }

    public void KeyboardMenu()
    {
        keyboardMenu.SetActive(true);
        keyboardButton.SetActive(false);
        controllerButton.SetActive(false);
    }

    public void ControllerMenu()
    {
        controllerMenu.SetActive(true);
        keyboardButton.SetActive(false);
        controllerButton.SetActive(false);
    }
}
