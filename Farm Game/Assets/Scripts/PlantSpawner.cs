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

    [SerializeField]
    private GameObject vegetableSpawner;
    [SerializeField]
    private GameObject beet;
    [SerializeField]
    private GameObject cabbage;
    [SerializeField]
    private GameObject carrot;
    [SerializeField]
    private GameObject corn;
    [SerializeField]
    private GameObject redPepper;
    [SerializeField]
    private float placeX;
    [SerializeField]
    private float placeY;
    [SerializeField]
    private float placeZ;
    [SerializeField]
    private float chance;

    [SerializeField]
    public int plotAmount;


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
        placeX = Random.Range(4.5f,8.1f);
        placeY = Random.Range(0, 2.6f);
        placeZ = Random.Range(2.7f,-2.7f);
        MeshRaycast();
        if(MoneyManager.instance.money <= 0)
        {
            MoneyManager.instance.money = 0;
            MoneyManager.instance.moneyText.text = "P1 " + MoneyManager.instance.money.ToString("C");
        }
    }

    public void MeshRaycast()//Used to detect the squares/plots on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "Buy" && Input.GetButtonDown("P1Plant"))
            {
                BuyPlot();
            }
            if(hit.collider.tag == "Plant" && Input.GetButtonDown("P1Plant"))//If the player has enough money, they can plant a vegetable by pressing space
            {
                BuyVegetable();
            }
            if(hit.collider.tag == "Collect" && Input.GetButtonDown("P1Plant"))
            { 
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                CollectVegetable();
                SoundManagerScript.PlaySound("footstep_grass_004");
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
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            else if(plantAnimation.tag == "Beet" && MoneyManager.instance.money < MoneyManager.instance.beetCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
            if(plantAnimation.tag == "Cabbage" && MoneyManager.instance.money >= MoneyManager.instance.cabbageCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.cabbageCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            else if(plantAnimation.tag == "Cabbage" && MoneyManager.instance.money < MoneyManager.instance.cabbageCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
            if(plantAnimation.tag == "Carrot" && MoneyManager.instance.money >= MoneyManager.instance.carrotCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.carrotCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            else if(plantAnimation.tag == "Carrot" && MoneyManager.instance.money < MoneyManager.instance.carrotCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
            if(plantAnimation.tag == "Corn" && MoneyManager.instance.money >= MoneyManager.instance.cornCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.cornCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            else if(plantAnimation.tag == "Corn" && MoneyManager.instance.money < MoneyManager.instance.cornCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
            if(plantAnimation.tag == "RedPepper" && MoneyManager.instance.money >= MoneyManager.instance.redPepperCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.redPepperCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            else if(plantAnimation.tag == "RedPepper" && MoneyManager.instance.money < MoneyManager.instance.redPepperCost)
            {
                SoundManagerScript.PlaySound("error_006");
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
                if(Random.value <= chance)
                {
                    Instantiate(beet, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);//When the player collects the vegetable, there is a chance of spawning that vegetable in the animal pen
                }
            }
            if(hit.collider.transform.parent.tag == "Cabbage")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.cabbageAmount);
                if(Random.value <= chance)
                {
                    Instantiate(cabbage, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if(hit.collider.transform.parent.tag == "Carrot")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.carrotAmount);
                if(Random.value <= chance)
                {
                    Instantiate(carrot, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if(hit.collider.transform.parent.tag == "Corn")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.cornAmount);
                if(Random.value <= chance)
                {
                    Instantiate(corn, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if(hit.collider.transform.parent.tag == "RedPepper")
            {
                MoneyManager.instance.AddMoney(MoneyManager.instance.redPepperAmount);
                if(Random.value <= chance)
                {
                    Instantiate(redPepper, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
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
                plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
            else if(hit.collider.transform.parent.tag == "Buy10" && MoneyManager.instance.money < MoneyManager.instance.plotTenCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
            if(hit.collider.transform.parent.tag == "Buy40" && MoneyManager.instance.money >= MoneyManager.instance.plotFortyCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.plotFortyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
            else if(hit.collider.transform.parent.tag == "Buy40" && MoneyManager.instance.money < MoneyManager.instance.plotFortyCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
            if(hit.collider.transform.parent.tag == "Buy70" && MoneyManager.instance.money >= MoneyManager.instance.plotSeventyCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.plotSeventyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
            else if(hit.collider.transform.parent.tag == "Buy70" && MoneyManager.instance.money < MoneyManager.instance.plotSeventyCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
            if(hit.collider.transform.parent.tag == "Buy100" && MoneyManager.instance.money >= MoneyManager.instance.plotHundredCost)
            {
                MoneyManager.instance.LoseMoney(MoneyManager.instance.plotHundredCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
                plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
            else if(hit.collider.transform.parent.tag == "Buy100" && MoneyManager.instance.money < MoneyManager.instance.plotHundredCost)
            {
                SoundManagerScript.PlaySound("error_006");
            }
        }
    }
}
