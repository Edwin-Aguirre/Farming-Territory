using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script is used for the menu buttons

    [SerializeField]
    private GameObject htpMenu;
    [SerializeField]
    private GameObject mainMenu;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    }
}
