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

    public bool player2;
    //Temp
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

    public MoneyManager2 _money;
    public MoneyManager mm;

    private void Awake()
    {
        if(!player2)
            if (instance != null && instance != this)
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
        if(!player2)
        {
            placeX = Random.Range(4.5f, 8.1f);
            placeY = Random.Range(0, 2.6f);
            placeZ = Random.Range(2.7f, -2.7f);

            MeshRaycast();
            if (mm.money <= 0)
            {
                mm.money = 0;
                mm.moneyText.text = mm.money.ToString("C");
            }
        } else
        {
            //player 2 abilities
            MeshRaycast2();
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
   
    public void MeshRaycast2()//Used to detect the squares/plots on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if (hit.collider.tag == "Plant" && Input.GetKeyDown(KeyCode.Return))//If the player has enough money, they can plant a vegetable by pressing space
            {
                BuyVegetable2();
            }
            else if (hit.collider.tag == "Collect" && Input.GetKeyDown(KeyCode.Return))
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
            if(plantAnimation.tag == "Beet" && mm.money >= mm.beetCost)
            {
                mm.LoseMoney(mm.beetCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "Cabbage" && mm.money >= mm.cabbageCost)
            {
                mm.LoseMoney(mm.cabbageCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "Carrot" && mm.money >= mm.carrotCost)
            {
                mm.LoseMoney(mm.carrotCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "Corn" && mm.money >= mm.cornCost)
            {
                mm.LoseMoney(mm.cornCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if(plantAnimation.tag == "RedPepper" && mm.money >= mm.redPepperCost)
            {
                mm.LoseMoney(mm.redPepperCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
        }
    }
    void BuyVegetable2()//Takes away money when each vegetable is bought by planting it
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if (plantAnimation.tag == "Beet" && _money.money >= _money.beetCost)
            {
                _money.LoseMoney(_money.beetCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if (plantAnimation.tag == "Cabbage" && _money.money >= _money.cabbageCost)
            {
                _money.LoseMoney(_money.cabbageCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if (plantAnimation.tag == "Carrot" && _money.money >= _money.carrotCost)
            {
                _money.LoseMoney(_money.carrotCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if (plantAnimation.tag == "Corn" && _money.money >= _money.cornCost)
            {
                _money.LoseMoney(_money.cornCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(plantAnimation, hit.transform.position, transform.rotation);
            }
            if (plantAnimation.tag == "RedPepper" && _money.money >= _money.redPepperCost)
            {
                _money.LoseMoney(_money.redPepperCost);
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
                mm.AddMoney(mm.beetAmount);
                if(Random.value <= chance)
                {
                    Instantiate(beet, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);//When the player collects the vegetable, there is a chance of spawning that vegetable in the animal pen
                }
            }
            if(hit.collider.transform.parent.tag == "Cabbage")
            {
                mm.AddMoney(mm.cabbageAmount);
                if(Random.value <= chance)
                {
                    Instantiate(cabbage, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if(hit.collider.transform.parent.tag == "Carrot")
            {
                mm.AddMoney(mm.carrotAmount);
                if(Random.value <= chance)
                {
                    Instantiate(carrot, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if(hit.collider.transform.parent.tag == "Corn")
            {
                mm.AddMoney(mm.cornAmount);
                if(Random.value <= chance)
                {
                    Instantiate(corn, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if(hit.collider.transform.parent.tag == "RedPepper")
            {
                mm.AddMoney(mm.redPepperAmount);
                if(Random.value <= chance)
                {
                    Instantiate(redPepper, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
        }
    }
    void CollectVegetable2()//Collects the vegetable and gives player money
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if (hit.collider.transform.parent.tag == "Beet")
            {
                _money.AddMoney(_money.beetAmount);
                if (Random.value <= chance)
                {
                    Instantiate(beet, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);//When the player collects the vegetable, there is a chance of spawning that vegetable in the animal pen
                }
            }
            if (hit.collider.transform.parent.tag == "Cabbage")
            {
                _money.AddMoney(_money.cabbageAmount);
                if (Random.value <= chance)
                {
                    Instantiate(cabbage, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if (hit.collider.transform.parent.tag == "Carrot")
            {
                _money.AddMoney(_money.carrotAmount);
                if (Random.value <= chance)
                {
                    Instantiate(carrot, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if (hit.collider.transform.parent.tag == "Corn")
            {
                _money.AddMoney(_money.cornAmount);
                if (Random.value <= chance)
                {
                    Instantiate(corn, vegetableSpawner.transform.position = new Vector3(placeX, placeY, placeZ), transform.rotation);
                }
            }
            if (hit.collider.transform.parent.tag == "RedPepper")
            {
                _money.AddMoney(_money.redPepperAmount);
                if (Random.value <= chance)
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
            if(hit.collider.transform.parent.tag == "Buy10" && mm.money >= mm.plotTenCost)
            {
                mm.LoseMoney(mm.plotTenCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
            if(hit.collider.transform.parent.tag == "Buy40" && mm.money >= mm.plotFortyCost)
            {
                mm.LoseMoney(mm.plotFortyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
            if(hit.collider.transform.parent.tag == "Buy70" && mm.money >= mm.plotSeventyCost)
            {
                mm.LoseMoney(mm.plotSeventyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
            if(hit.collider.transform.parent.tag == "Buy100" && mm.money >= mm.plotHundredCost)
            {
                mm.LoseMoney(mm.plotHundredCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(emptyPlot, hit.transform.position, transform.rotation);
            }
        }
    }
}
