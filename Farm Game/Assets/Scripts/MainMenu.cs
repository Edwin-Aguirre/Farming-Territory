using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script is used for the menu buttons

    [SerializeField]
    private GameObject htpMenu;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject playMenu;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject controlsMenu;

    [SerializeField]
    private GameObject mainPlayButton;
    [SerializeField]
    private GameObject gamemodePlayButton;
    [SerializeField]
    private GameObject htpButton;
    [SerializeField]
    private GameObject settingsButton;
    [SerializeField]
    private GameObject controlsButton;
    [SerializeField]
    private GameObject musicSlider;
    [SerializeField]
    private GameObject keyboardButton;

    private void Update() 
    {
        if(Input.GetButtonDown("Pause/Back"))
        {
            if(htpMenu.activeInHierarchy)
            {
                htpMenu.SetActive(false);
                mainMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(htpButton);
            }
            if(playMenu.activeInHierarchy)
            {
                playMenu.SetActive(false);
                mainMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(mainPlayButton);
            }
            if(settingsMenu.activeInHierarchy)
            {
                settingsMenu.SetActive(false);
                mainMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(settingsButton);
            }
            if(controlsMenu.activeInHierarchy)
            {
                controlsMenu.SetActive(false);
                mainMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(controlsButton);
            }
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAI()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        htpMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
        mainMenu.SetActive(true);
        htpMenu.SetActive(false);
        playMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void PlayMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gamemodePlayButton);
        EventSystem.current.firstSelectedGameObject = gamemodePlayButton;
        playMenu.SetActive(true);
        mainMenu.SetActive(false);
        htpMenu.SetActive(false);
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void SettingsMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(musicSlider);
        EventSystem.current.firstSelectedGameObject = musicSlider;
        settingsMenu.SetActive(true);
        playMenu.SetActive(false);
        mainMenu.SetActive(false);
        htpMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(keyboardButton);
        EventSystem.current.firstSelectedGameObject = keyboardButton;
        controlsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);
        mainMenu.SetActive(false);
        htpMenu.SetActive(false);
    }
}
