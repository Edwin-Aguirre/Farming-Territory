using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    //This script handles the Shop in the game.
    //By clicking on a vegetable on the left, it will let you buy them.
    //This is still WIP

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
        if(this.tag == "Beet" && MoneyManager.instance.money >= MoneyManager.instance.beetCost)
        {
            PlantSpawner.instance.plantAnimation = beetAnimation;
        }
        if(this.tag == "Cabbage" && MoneyManager.instance.money >= MoneyManager.instance.cabbageCost)
        {
            PlantSpawner.instance.plantAnimation = cabbageAnimation;
        }
        if(this.tag == "Carrot" && MoneyManager.instance.money >= MoneyManager.instance.carrotCost)
        {
            PlantSpawner.instance.plantAnimation = carrotAnimation;
        }
        if(this.tag == "Corn" && MoneyManager.instance.money >= MoneyManager.instance.cornCost)
        {
            PlantSpawner.instance.plantAnimation = cornAnimation;
        }
        if(this.tag == "RedPepper" && MoneyManager.instance.money >= MoneyManager.instance.redPepperCost)
        {
            PlantSpawner.instance.plantAnimation = redPepperAnimation;
        }
    }
}
