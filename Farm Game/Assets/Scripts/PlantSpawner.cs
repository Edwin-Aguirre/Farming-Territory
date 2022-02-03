using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script allows the player to spawn vegetable objects to plant in the ground
    //Press space on an empty plot
    
    public static PlantSpawner instance;

    [SerializeField]
    private Mesh emptyPlotMesh;

    [SerializeField]
    public GameObject plantAnimation;


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
       
    }

    // Update is called once per frame
    void Update()
    {
        MeshRaycast();
    }

    public void MeshRaycast()//Used to detect the squares/plots on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "Buy" && Input.GetKeyDown("space"))
            {
                hit.transform.gameObject.tag = "Plant";//When the player collects the plant, it changes its tag so you can plant seeds.
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<MeshFilter>();
                if(selectionRenderer != null)
                {
                    selectionRenderer.mesh = emptyPlotMesh;
                }
            }
            else if(hit.collider.tag == "Plant" && Input.GetKeyDown("space") && MoneyManager.instance.money > 0)//If the player has enough money, they can plant a vegetable by pressing space
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<MeshFilter>();
                if(selectionRenderer != null)
                {
                    Destroy(hit.transform.parent.gameObject);
                    Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                    BuyVegetable();

                    if(MoneyManager.instance.money <= 0)
                    {
                       MoneyManager.instance.money = 0;
                       MoneyManager.instance.moneyText.text = "$" + MoneyManager.instance.money.ToString();
                    }
                }
            }
        }
    }

    void BuyVegetable()//Takes away money when each vegetable is bought by planting it
    {
        if(plantAnimation.tag == "Beet")
        {
            MoneyManager.instance.LoseMoney(MoneyManager.instance.beetCost);
        }
        if(plantAnimation.tag == "Cabbage")
        {
            MoneyManager.instance.LoseMoney(MoneyManager.instance.cabbageCost);
        }
        if(plantAnimation.tag == "Carrot")
        {
            MoneyManager.instance.LoseMoney(MoneyManager.instance.carrotCost);
        }
        if(plantAnimation.tag == "Corn")
        {
            MoneyManager.instance.LoseMoney(MoneyManager.instance.cornCost);
        }
        if(plantAnimation.tag == "RedPepper")
        {
            MoneyManager.instance.LoseMoney(MoneyManager.instance.redPepperCost);
        }
    }
}
