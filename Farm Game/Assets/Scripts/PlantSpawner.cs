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
            if(hit.collider.tag == "Plant" && Input.GetKeyDown("space") && MoneyManager.instance.money > 0)//If the player has enough money, they can plant a vegetable by pressing space
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
}
