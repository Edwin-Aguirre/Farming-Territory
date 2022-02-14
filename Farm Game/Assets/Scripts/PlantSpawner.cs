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

    [SerializeField]
    private GameObject emptyPlot;


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
        if(MoneyManager.instance.money <= 0)
        {
            MoneyManager.instance.money = 0;
            MoneyManager.instance.moneyText.text = MoneyManager.instance.money.ToString("C");
        }
    }

    public void MeshRaycast()//Used to detect the squares/plots on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "Buy" && Input.GetKeyDown("space"))
            {
                BuyPlot();
            }
            if(hit.collider.tag == "Plant" && Input.GetKeyDown("space"))//If the player has enough money, they can plant a vegetable by pressing space
            {
                BuyVegetable();
            }
            else if(hit.collider.tag == "Collect" && Input.GetKeyDown("space"))
            { 
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                CollectVegetable();
            }
        }
    }

    void BuyVegetable()//Takes away money when each vegetable is bought by planting it
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(plantAnimation.tag == "Beet" && MoneyManager.instance.money >= MoneyManager.instance.beetCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.beetCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "Cabbage" && MoneyManager.instance.money >= MoneyManager.instance.cabbageCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.cabbageCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "Carrot" && MoneyManager.instance.money >= MoneyManager.instance.carrotCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.carrotCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "Corn" && MoneyManager.instance.money >= MoneyManager.instance.cornCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.cornCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "RedPepper" && MoneyManager.instance.money >= MoneyManager.instance.redPepperCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.redPepperCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
        }
    }

    void CollectVegetable()//Collects the vegetable and gives player money
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.transform.parent.tag == "Beet")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.beetAmount);
            }
            if(hit.collider.transform.parent.tag == "Cabbage")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.cabbageAmount);
            }
            if(hit.collider.transform.parent.tag == "Carrot")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.carrotAmount);
            }
            if(hit.collider.transform.parent.tag == "Corn")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.cornAmount);
            }
            if(hit.collider.transform.parent.tag == "RedPepper")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.redPepperAmount);
            }
        }
    }

    void BuyPlot()//Buys the plot of land
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.transform.parent.tag == "Buy10" && MoneyManager.instance.money >= MoneyManager.instance.plotTenCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.plotTenCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
            if(hit.collider.transform.parent.tag == "Buy40" && MoneyManager.instance.money >= MoneyManager.instance.plotFortyCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.plotFortyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
            if(hit.collider.transform.parent.tag == "Buy70" && MoneyManager.instance.money >= MoneyManager.instance.plotSeventyCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.plotSeventyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
            if(hit.collider.transform.parent.tag == "Buy100" && MoneyManager.instance.money >= MoneyManager.instance.plotHundredCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.plotHundredCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
        }
    }
}
