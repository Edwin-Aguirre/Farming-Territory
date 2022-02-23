using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalShopIndicators : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script visually helps player 1 know what they can buy
    //If you don't have enough money, then an x will appear, otherwise an arrow will appear 
    
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

        AnimalIndicators();
    }

    void AnimalIndicators()
    {
        if(MoneyManager.instance.money >= MoneyManager.instance.cowCost)
       {
           arrow[0].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.sheepCost)
       {
           arrow[1].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.chickenCost)
       {
           arrow[2].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.pigCost)
       {
           arrow[3].SetActive(true);
       }
       if(MoneyManager.instance.money >= MoneyManager.instance.horseCost)
       {
           arrow[4].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.cowCost)
       {
           arrow[0].SetActive(false);
           x[0].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.sheepCost)
       {
           arrow[1].SetActive(false);
           x[1].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.chickenCost)
       {
           arrow[2].SetActive(false);
           x[2].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.pigCost)
       {
           arrow[3].SetActive(false);
           x[3].SetActive(true);
       }
       if(MoneyManager.instance.money < MoneyManager.instance.horseCost)
       {
           arrow[4].SetActive(false);
           x[4].SetActive(true);
       }
    }
}
