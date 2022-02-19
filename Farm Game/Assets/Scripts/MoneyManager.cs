using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This is a script that handles the currency in the game

    public static MoneyManager instance;

    [SerializeField]
    public Text moneyText;

    [SerializeField]
    public Text multiplierText;

    [SerializeField]
    public float money;

    [SerializeField]
    public float multiplier;

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

    [SerializeField]
    public int plotTenCost;
    public int plotFortyCost;
    public int plotSeventyCost;
    public int plotHundredCost;

    [SerializeField]
    public int cowCost;
    public int sheepCost;
    public int chickenCost;
    public int pigCost;
    public int horseCost;

    [SerializeField]
    public float cowMultiplier;
    public float sheepMultiplier;
    public float chickenMultiplier;
    public float pigMultiplier;
    public float horseMultiplier;


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
        moneyText.text = money.ToString("C");
        multiplierText.text = "x" + multiplier.ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        money += amount * multiplier;
        moneyText.text = money.ToString("C");
    }

    public void LoseMoney(int lose)
    {
        money -= lose;
        moneyText.text = money.ToString("C");
    }
}
