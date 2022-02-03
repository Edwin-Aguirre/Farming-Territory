using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This is a WIP script that handles the currency in the game

    public static MoneyManager instance;

    [SerializeField]
    public Text moneyText;

    [SerializeField]
    public int money;

    [SerializeField]
    public int beetAmount;
    public int beetCost;

    [SerializeField]
    public int cabbageAmount;
    public int cabbageCost;

    [SerializeField]
    public int carrotAmount;
    public int carrotCost;

    [SerializeField]
    public int cornAmount;
    public int cornCost;

    [SerializeField]
    public int redPepperAmount;
    public int redPepperCost;

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

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

    public void LoseMoney(int lose)
    {
        money -= lose;
        moneyText.text = "$" + money.ToString();
    }
}
