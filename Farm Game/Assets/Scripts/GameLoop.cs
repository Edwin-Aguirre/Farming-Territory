using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script handles the win/lose game loop

    [SerializeField]
    private GameObject winScreen;

    [SerializeField]
    private GameObject loseScreen;

    [SerializeField]
    private int amountToWin;

    [SerializeField]
    private Text objectiveText;

    [SerializeField]
    private string objectiveMessage;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        setObjectiveText();
        objectiveText.text = objectiveMessage;
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        LoseGame();
    }

    void WinGame()//If the player earns enough $, then you win
    {
        if(MoneyManager.instance.money >= amountToWin)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
            PauseMenu.instance.pauseMenuUI.SetActive(false);
        }
    }

    public void LoseGame()//If the player !earn enough $, then the lose screen appears
    {
        if(Timer.instance.timeValue <= 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0;
            PauseMenu.instance.pauseMenuUI.SetActive(false);
        }
    }

    public void TryAgain()//Clicking the try again button reloads the scene
    {
        SceneManager.LoadScene(1);
    }

    //Shows the objective text for 3 seconds
    IEnumerator ObjectiveDuration()
    {
        yield return new WaitForSeconds(3f);
        objectiveText.text = "";
    }

    //Sets the objective text
    void setObjectiveText()
    {
        StartCoroutine(ObjectiveDuration());
    }
}
