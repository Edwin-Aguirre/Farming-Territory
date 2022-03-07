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
    private GameObject mainPlayButton;
    [SerializeField]
    private GameObject gamemodePlayButton;
    [SerializeField]
    private GameObject htpButton;

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
    }

    public void PlayMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gamemodePlayButton);
        EventSystem.current.firstSelectedGameObject = gamemodePlayButton;
        playMenu.SetActive(true);
        mainMenu.SetActive(false);
        htpMenu.SetActive(false);
    }
}
