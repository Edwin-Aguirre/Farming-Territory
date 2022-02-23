using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner2 : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script allows player 2 to select and buy an animal
    
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
    private Vector3 moveRightUnits = new Vector3(0.9f,0,0);
    private Vector3 moveLefttUnits = new Vector3(-0.9f,0,0);

    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private GameObject animalSpawner;

    [SerializeField]
    private GameObject animal;
    
    [SerializeField]
    private GameObject cow;
    [SerializeField]
    private GameObject sheep;
    [SerializeField]
    private GameObject chicken;
    [SerializeField]
    private GameObject pig;
    [SerializeField]
    private GameObject horse;

    [SerializeField]
    private float placeX;

    [SerializeField]
    private float placeZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimalShopRaycast();
        ShopMovement();
        WallRightRaycast();
        WallLeftRaycast();
        BuyAnimal();
        MoneyManager2.instance.multiplierText2.text = "P2 " + "x" + MoneyManager2.instance.multiplier2.ToString("0.0");
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    void ShopMovement()//Moves the Shop selector for player 2 with / and ,
    {
        if(Input.GetKey(KeyCode.Slash) && !isMoving)
        {
            StartCoroutine(MovePlayer((moveRightUnits)));
        }
        if(Input.GetKey(KeyCode.Comma) && !isMoving)
        {
            StartCoroutine(MovePlayer((moveLefttUnits)));
        }
    }

    public void WallRightRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.right);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallRight")
            {
                targetPos = origPos;
            }
            
        }
    }

    public void WallLeftRaycast()//For the boundary of the level. Stops the player from leaving the fence.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.left);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "WallLeft")
            {
                targetPos = origPos;
            }
            
        }
    }

    void AnimalShopRaycast()//Uses a raycast to know what animal is selected and will spawn the animal that is detected
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "BuyCow" && MoneyManager2.instance.money2 >= MoneyManager2.instance.cowCost)
            {
                animal = cow;
            }
            if(hit.collider.tag == "BuySheep" && MoneyManager2.instance.money2 >= MoneyManager2.instance.sheepCost)
            {
                animal = sheep;
            }
            if(hit.collider.tag == "BuyChicken" && MoneyManager2.instance.money2 >= MoneyManager2.instance.chickenCost)
            {
                animal = chicken;
            }
            if(hit.collider.tag == "BuyPig" && MoneyManager2.instance.money2 >= MoneyManager2.instance.pigCost)
            {
                animal = pig;
            }
            if(hit.collider.tag == "BuyHorse" && MoneyManager2.instance.money2 >= MoneyManager2.instance.horseCost)
            {
                animal = horse;
            }
        }
    }

    void BuyAnimal()//Buys animal, takes away money, spawns it and also gives the multiplier.
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        //These values are based on the size of player 2 animal pen and randomly chooses a spot to spawn the animal.
        placeX = Random.Range(4.5f,8.1f);
        placeZ = Random.Range(4.5f,9.9f);
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "BuyCow" && MoneyManager2.instance.money2 >= MoneyManager2.instance.cowCost && Input.GetKeyDown(KeyCode.Period))
            {
                MoneyManager2.instance.LoseMoney2(MoneyManager2.instance.cowCost);
                Instantiate(animal, animalSpawner.transform.position = new Vector3(placeX, transform.position.y, placeZ), transform.rotation);
                MoneyManager2.instance.multiplier2 += MoneyManager2.instance.cowMultiplier;//Sets the multipler to the animal multipler and adds that by the amount of animals that were bought.
            }
        }
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "BuySheep" && MoneyManager2.instance.money2 >= MoneyManager2.instance.sheepCost && Input.GetKeyDown(KeyCode.Period))
            {
                MoneyManager2.instance.LoseMoney2(MoneyManager2.instance.sheepCost);
                Instantiate(animal, animalSpawner.transform.position = new Vector3(placeX, transform.position.y, placeZ), transform.rotation);
                MoneyManager2.instance.multiplier2 += MoneyManager2.instance.sheepMultiplier;
            }
        }
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "BuyChicken" && MoneyManager2.instance.money2 >= MoneyManager2.instance.chickenCost && Input.GetKeyDown(KeyCode.Period))
            {
                MoneyManager2.instance.LoseMoney2(MoneyManager2.instance.chickenCost);
                Instantiate(animal, animalSpawner.transform.position = new Vector3(placeX, transform.position.y, placeZ), transform.rotation);
                MoneyManager2.instance.multiplier2 += MoneyManager2.instance.chickenMultiplier;
            }
        }
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "BuyPig" && MoneyManager2.instance.money2 >= MoneyManager2.instance.pigCost && Input.GetKeyDown(KeyCode.Period))
            {
                MoneyManager2.instance.LoseMoney2(MoneyManager2.instance.pigCost);
                Instantiate(animal, animalSpawner.transform.position = new Vector3(placeX, transform.position.y, placeZ), transform.rotation);
                MoneyManager2.instance.multiplier2 += MoneyManager2.instance.pigMultiplier;
            }
        }
        if(Physics.Raycast(myRay, out hit))
        {
            if(hit.collider.tag == "BuyHorse" && MoneyManager2.instance.money2 >= MoneyManager2.instance.horseCost && Input.GetKeyDown(KeyCode.Period))
            {
                MoneyManager2.instance.LoseMoney2(MoneyManager2.instance.horseCost);
                Instantiate(animal, animalSpawner.transform.position = new Vector3(placeX, transform.position.y, placeZ), transform.rotation);
                MoneyManager2.instance.multiplier2 += MoneyManager2.instance.horseMultiplier;
            }
        }
    }
}
