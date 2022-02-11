using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    //Written by Edwin Aguirre
    //This script allows the player to select and buy an animal
    
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

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
        placeX = Random.Range(4.5f,8.1f);
    
        placeZ = Random.Range(2.7f,-2.7f);
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(animal, animalSpawner.transform.position = new Vector3(placeX, transform.position.y, placeZ), transform.rotation);
        }
        AnimalShopRaycast();
        ShopMovement();
        WallRightRaycast();
        WallLeftRaycast();
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

    void ShopMovement()//Moving with wasd in a grid layout
    {
        if(Input.GetKey(KeyCode.C) && !isMoving)
        {
            StartCoroutine(MovePlayer(new Vector3(0.9f,0,0)));
        }
        if(Input.GetKey(KeyCode.Z) && !isMoving)
        {
            StartCoroutine(MovePlayer(new Vector3(-0.9f,0,0)));
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

    void AnimalShopRaycast()
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(myRay, out hit, rayDistance))
        {
            if(hit.collider.tag == "BuyCow" && MoneyManager.instance.money >= MoneyManager.instance.cowCost)
            {
                animal = cow;
            }
            if(hit.collider.tag == "BuySheep" && MoneyManager.instance.money >= MoneyManager.instance.sheepCost)
            {
                animal = sheep;
            }
            if(hit.collider.tag == "BuyChicken" && MoneyManager.instance.money >= MoneyManager.instance.chickenCost)
            {
                animal = chicken;
            }
            if(hit.collider.tag == "BuyPig" && MoneyManager.instance.money >= MoneyManager.instance.pigCost)
            {
                animal = pig;
            }
            if(hit.collider.tag == "BuyHorse" && MoneyManager.instance.money >= MoneyManager.instance.horseCost)
            {
                animal = horse;
            }
        }
    }
}
