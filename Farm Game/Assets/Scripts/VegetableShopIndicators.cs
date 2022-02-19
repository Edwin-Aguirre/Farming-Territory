using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableShopIndicators : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script visually helps the player know what they can buy
    //If you don't have enough money, then an x will appear, otherwise a check will appear 

    [SerializeField]
    private GameObject[] arrow;

    [SerializeField]
    private GameObject[] x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < arrow.Length; i++)
        {
            arrow[i].SetActive(false);
        }
        for (int i = 0; i < x.Length; i++)
        {
            x[i].SetActive(false);
        }

        VegetableIndicators();
    }

    void VegetableIndicators()
    {
        if(MoneyManager.instance.money >= MoneyManager.instance.beetCost)
       {
           arrow[0].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.cabbageCost)
       {
           arrow[1].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.carrotCost)
       {
           arrow[2].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.cornCost)
       {
           arrow[3].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.redPepperCost)
       {
           arrow[4].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.beetCost)
       {
           arrow[0].SetActive(false);
           x[0].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.cabbageCost)
       {
           arrow[1].SetActive(false);
           x[1].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.carrotCost)
       {
           arrow[2].SetActive(false);
           x[2].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.cornCost)
       {
           arrow[3].SetActive(false);
           x[3].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.redPepperCost)
       {
           arrow[4].SetActive(false);
           x[4].SetActive(true);
       }
    }
}
