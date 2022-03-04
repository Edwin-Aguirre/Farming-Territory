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
    private GameObject p1WinScreen;

    [SerializeField]
    private GameObject p2WinScreen;

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

    void WinGame()//If either player buys out all the plots of land, then they win
    {
        if(PlantSpawner.instance.plotAmount == amountToWin)
        {
            p1WinScreen.SetActive(true);
            Time.timeScale = 0;
            PauseMenu.instance.pauseMenuUI.SetActive(false);
        }
        else if(PlayerTwo.instance.plotAmount == amountToWin)
        {
            p2WinScreen.SetActive(true);
            Time.timeScale = 0;
            PauseMenu.instance.pauseMenuUI.SetActive(false);
        }
    }

    public void LoseGame()//If the timer runs out, then the lose screen appears
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
