using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField]
    private GameObject beetAnimation;

    [SerializeField]
    private GameObject cabbageAnimation;

    [SerializeField]
    private GameObject carrotAnimation;

    [SerializeField]
    private GameObject cornAnimation;

    [SerializeField]
    private GameObject redPepperAnimation;
    
    private void OnMouseDown() 
    {
        if(this.tag == "Beet" && MoneyManager.instance.money > MoneyManager.instance.beetAmount)
        {
            PlantSpawner.instance.plantAnimation = beetAnimation;
            //MoneyManager.instance.money -= MoneyManager.instance.beetAmount;
            //MoneyManager.instance.moneyText.text = "$" + MoneyManager.instance.money.ToString();
        }
        if(this.tag == "Cabbage")
        {
            PlantSpawner.instance.plantAnimation = cabbageAnimation;
        }
        if(this.tag == "Carrot")
        {
            PlantSpawner.instance.plantAnimation = carrotAnimation;
        }
        if(this.tag == "Corn")
        {
            PlantSpawner.instance.plantAnimation = cornAnimation;
        }
        if(this.tag == "RedPepper")
        {
            PlantSpawner.instance.plantAnimation = redPepperAnimation;
        }
    }
}
