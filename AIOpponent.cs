using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOpponent : MonoBehaviour
{
    //Written by Edwin Aguirre and Minsung Lee
    //this is not main script
    private bool isMoving;

    private Vector3 moveRightUnits = new Vector3(0.9f,0,0);
    private Vector3 moveLefttUnits = new Vector3(-0.9f,0,0);
    private Vector3 moveUpUnits = new Vector3(0,0,0.9f);
    private Vector3 moveDownUnits = new Vector3(0,0,-0.9f);

    [SerializeField]
    private float rayDistance;

    private int randomValue;
    private float moveRate = 1f;
    private float nextMove;

    [SerializeField]
    private PlayerTwo playerTwo;

    [SerializeField]
    private Shop2 shop2;

    [SerializeField]
    private MoneyManager2 mm2;

    private float timeToMove = 0.2f;
    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AIMovement();
        AIPlanting();
        AIBoundary();
        shop2.AIShop();
        OrderFindCloest();
    }

    private void AIMovement()
    {
        randomValue = Random.Range(1,5);
        if(randomValue == 1 && Time.time > nextMove && !isMoving)
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(playerTwo.MovePlayer(moveUpUnits));
        }
        if(randomValue == 2 && Time.time > nextMove && !isMoving)
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(playerTwo.MovePlayer(moveLefttUnits));
           }
        if(randomValue == 3 && Time.time > nextMove && !isMoving)
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(playerTwo.MovePlayer(moveDownUnits));
        }
        if(randomValue == 4 && Time.time > nextMove && !isMoving) 
        {
            nextMove = Time.time + moveRate;
            StartCoroutine(playerTwo.MovePlayer(moveRightUnits));
        }
    }

    private void AIBoundary()
    {
        playerTwo.WallDownRaycast();
        playerTwo.WallLeftRaycast();
        playerTwo.WallUpRaycast();
        playerTwo.WallRightRaycast();
    }

    private void AIPlanting()
    {
        MeshRaycastPlot2();
        MeshRaycastVegetable2();
        playerTwo.placeX = Random.Range(4.5f, 8.1f);
        playerTwo.placeY = Random.Range(0, 2.6f);
        playerTwo.placeZ = Random.Range(4.5f, 9.9f);
    }

    private void OrderFindCloest()
    {
        if (MoneyManager2.instance.money2 > 100)
        {
            BuyPlotsAI();
        }
        else if (MoneyManager2.instance.money2 > 10 && (gameObject.tag == "Plot") == true)
        {
            FindClosestPlant();
        }
        else if(MoneyManager2.instance.money2 == 0 || (gameObject.tag == "Collect") == true)
        {
            FindClosestCollect();
        }
    }
    private void FindClosestPlot() //detect plot that tagged buy
    {
        float distanceToClosestPlant = Mathf.Infinity;
        PlantAnimations closestPlant = null;
        PlantAnimations[] allPlants = GameObject.FindObjectsOfType<PlantAnimations>();

        foreach(PlantAnimations currentPlant in allPlants)
        {
            float distanceToPlant = (currentPlant.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToPlant < distanceToClosestPlant)
            {
                if(closestPlant.gameObject.tag == "Buy")
                {
                 distanceToClosestPlant = distanceToPlant;
                 closestPlant = currentPlant;
                 transform.position = Vector3.Lerp(this.transform.position, closestPlant.transform.position, (elapsedTime / timeToMove));
                }
            }
        }
        Debug.DrawLine(this.transform.position, closestPlant.transform.position);
    }

    private void FindClosestPlant() //detect plants that tagged plant
    {
        float distanceToClosestPlant = Mathf.Infinity;
        PlantAnimations closestPlant = null;
        PlantAnimations[] allPlants = GameObject.FindObjectsOfType<PlantAnimations>();

        foreach (PlantAnimations currentPlant in allPlants)
        {
            float distanceToPlant = (currentPlant.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlant < distanceToClosestPlant)
            {
                if(closestPlant.gameObject.tag == "Plant")
                {
                distanceToClosestPlant = distanceToPlant;
                closestPlant = currentPlant;
                transform.position = Vector3.Lerp(this.transform.position, closestPlant.transform.position, (elapsedTime / timeToMove));
                }
            }
        }
        Debug.DrawLine(this.transform.position, closestPlant.transform.position);
    }
    private void FindClosestCollect() // detect plants that tagged Collect
    {
        float distanceToClosestPlant = Mathf.Infinity;
        PlantAnimations closestPlant = null;
        PlantAnimations[] allPlants = GameObject.FindObjectsOfType<PlantAnimations>();

        foreach (PlantAnimations currentPlant in allPlants)
        {
            float distanceToPlant = (currentPlant.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlant < distanceToClosestPlant)
            {
                if(closestPlant.gameObject.tag == "Collect")
                {
                distanceToClosestPlant = distanceToPlant;
                closestPlant = currentPlant;
                transform.position = Vector3.Lerp(this.transform.position, closestPlant.transform.position, (elapsedTime / timeToMove));
                }
            }
        }
        Debug.DrawLine(this.transform.position, closestPlant.transform.position);
    }

    /*
     if(BuyPlotsAi() = true)
    {
    BuyPlotsAi();
    }
     else if(BuyPlotsAi() = false)
    {
    MeshRaycastVegetable2();
    } 
     */

    private void BuyPlotsAI() // Used to keep buying plots until no more plot to buy
    {
        int count = 0;
        int[] miniprice = new int[] { 10, 40, 70, 100 };
        int totalLandNum = 48;
        int tenLand = 8;
        int fortyLand = 16;
        int seventyLand = 10;
        int hundredLand = 14;
        if (count < 8)
        {
            for (int i = 0; i < tenLand; i++)
            {
                if (MoneyManager2.instance.money2 > miniprice[0])
                {
                    FindClosestPlot();
                    MeshRaycastPlot2();
                    count++;
                }
                if (i == 8)
                {
                    break;
                }
            }
        }
        else if (count < 24)
        {
            for (int i = 0; i < fortyLand; i++)
            {
                if (MoneyManager2.instance.money2 > miniprice[1])
                {
                    FindClosestPlot();
                    MeshRaycastPlot2();
                    count++;
                }
                if (i == 24)
                {
                    break;
                }
            }
        }
        else if (count < 34)
            for (int i = 0; i < seventyLand; i++)
            {
                if (MoneyManager2.instance.money2 > miniprice[2])
                {
                    FindClosestPlot();
                    MeshRaycastPlot2();
                    count++;
                }
                if (i == 34)
                {
                    break;
                }
            }
        else if (count < 48)
        {
            for (int i = 0; i < hundredLand; i++)
            {
                if (MoneyManager2.instance.money2 > miniprice[3])
                {
                    FindClosestPlot();
                    MeshRaycastPlot2();
                    count++;
                }
                if (i == 48)
                {
                    break;
                }
            }
        }
        if(count == totalLandNum)
        {
            //ai win
        }
    }

    private void MeshRaycastPlot2()//Used to detect the squares/plots on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "Buy") 
            {
                playerTwo.BuyPlot2();
            }
        }
    }
    private void MeshRaycastVegetable2()//Used to detect the squares/plots for vegetable on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if (hit.collider.tag == "Plant")
            {
                playerTwo.BuyVegetable2();
            }
            else if (hit.collider.tag == "Collect")
            {
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.emptyPlot, hit.transform.position, transform.rotation);
                playerTwo.CollectVegetable2();
            }
        }
    }
}
