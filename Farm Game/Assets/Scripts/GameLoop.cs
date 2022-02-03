using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject winScreen;

    [SerializeField]
    private int amountToWin;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
    }

    void WinGame()
    {
        if(MoneyManager.instance.money >= amountToWin)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
}
