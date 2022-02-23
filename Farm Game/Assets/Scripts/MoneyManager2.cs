using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager2 : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This is a script that handles the currency in the game for Player 2
    //Everything is public because they are used in other scripts

    public static MoneyManager2 instance;

    [SerializeField]
    public Text moneyText2;

    [SerializeField]
    public Text multiplierText2;

    [SerializeField]
    public float money2;

    [SerializeField]
    public float multiplier2;

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
        multiplierText2.text = "P2 " + "x" + multiplier2.ToString("0.0");
        moneyText2.text = "P2 " + money2.ToString("C");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney2(int amount)
    {
        money2 += amount * multiplier2;
        moneyText2.text = "P2 " + money2.ToString("C");
    }

    public void LoseMoney2(int lose)
    {
        money2 -= lose;
        moneyText2.text = "P2 " + money2.ToString("C");
    }
}
