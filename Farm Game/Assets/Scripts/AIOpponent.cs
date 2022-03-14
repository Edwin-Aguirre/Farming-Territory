using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOpponent : MonoBehaviour
{
    //Written by Edwin Aguirre 
    
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

    [SerializeField]
    private float maxDistance;

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
        FindClosestPlant();
        FindClosestPlot();
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
        MeshRaycast2();
        playerTwo.placeX = Random.Range(4.5f, 8.1f);
        playerTwo.placeY = Random.Range(0, 2.6f);
        playerTwo.placeZ = Random.Range(4.5f, 9.9f);
    }

    private void FindClosestPlant()
    {
        float distanceToClosestPlant = Mathf.Infinity;
        PlantAnimations closestPlant = null;
        PlantAnimations[] allPlants = GameObject.FindObjectsOfType<PlantAnimations>();

        foreach(PlantAnimations currentPlant in allPlants)
        {
            float distanceToPlant = (currentPlant.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToPlant < distanceToClosestPlant)
            {
                distanceToClosestPlant = distanceToPlant;
                closestPlant = currentPlant;
            }
        }
        transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, 0.1f, this.transform.position.z ), closestPlant.transform.position, distanceToClosestPlant);
    }

    private GameObject FindClosestPlot()
    {
        GameObject[] plots;
        plots = GameObject.FindGameObjectsWithTag("Buy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject  plot in plots)
        {
            Vector3 diff = plot.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = plot;
                distance = curDistance;
                transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, 0.1f, this.transform.position.z ), closest.transform.position, maxDistance);
            }
        }
        return closest;
    }

    private void MeshRaycast2()//Used to detect the squares/plots on the ground
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "Buy") 
            {
                BuyPlot2();//Didn't use these from playerTwo because I wanted to remove the error sound. Otherwise the AI would break the sound
            }
            if (hit.collider.tag == "Plant") 
            {
                BuyVegetable2();//Didn't use these from playerTwo because I wanted to remove the error sound
            }
            else if (hit.collider.tag == "Collect")
            {
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.emptyPlot, hit.transform.position, transform.rotation);
                playerTwo.CollectVegetable2();
            }
        }
    }

    private void BuyPlot2()//Buys the plot of land
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.transform.parent.tag == "Buy10" && mm2.money2 >= mm2.plotTenCost)
            {
                mm2.LoseMoney2(mm2.plotTenCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.emptyPlot, hit.transform.position, transform.rotation);
                playerTwo.plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
            if(hit.collider.transform.parent.tag == "Buy40" && mm2.money2 >= mm2.plotFortyCost)
            {
                mm2.LoseMoney2(mm2.plotFortyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.emptyPlot, hit.transform.position, transform.rotation);
                playerTwo.plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
            if(hit.collider.transform.parent.tag == "Buy70" && mm2.money2 >= mm2.plotSeventyCost)
            {
                mm2.LoseMoney2(mm2.plotSeventyCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.emptyPlot, hit.transform.position, transform.rotation);
                playerTwo.plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
            if(hit.collider.transform.parent.tag == "Buy100" && mm2.money2 >= mm2.plotHundredCost)
            {
                mm2.LoseMoney2(mm2.plotHundredCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.emptyPlot, hit.transform.position, transform.rotation);
                playerTwo.plotAmount++;
                SoundManagerScript.PlaySound("footstep_grass_000");
            }
        }
    }

    private void BuyVegetable2()//Takes away money when each vegetable is bought by planting it
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit))
        {
            if (playerTwo.plantAnimation.tag == "Beet" && mm2.money2 >= mm2.beetCost)
            {
                mm2.LoseMoney2(mm2.beetCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (playerTwo.plantAnimation.tag == "Cabbage" && mm2.money2 >= mm2.cabbageCost)
            {
                mm2.LoseMoney2(mm2.cabbageCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (playerTwo.plantAnimation.tag == "Carrot" && mm2.money2 >= mm2.carrotCost)
            {
                mm2.LoseMoney2(mm2.carrotCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (playerTwo.plantAnimation.tag == "Corn" && mm2.money2 >= mm2.cornCost)
            {
                mm2.LoseMoney2(mm2.cornCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
            if (playerTwo.plantAnimation.tag == "RedPepper" && mm2.money2 >= mm2.redPepperCost)
            {
                mm2.LoseMoney2(mm2.redPepperCost);
                Destroy(hit.transform.parent.gameObject);
                Instantiate(playerTwo.plantAnimation, hit.transform.position, transform.rotation);
                SoundManagerScript.PlaySound("footstep_grass_002");
            }
        }
    }
}
